using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TroncoMovilScript : MonoBehaviour {

    public float fuerzaMaxFrenado = 10;
    float anguloMaxRotacion = 20;
    private float vPos;
    float hPos;
    private WheelCollider wcFrontL, wcFrontR, wcBackL, wcBackR;
    public float fuerzaMotor = 100;
    public float incrementoFrenada = 10;
    //private float fuerzaMaxFrenado = 0;
    bool frenoManoActivo = true;
    public Text txtFrenoMano;
    public Text txtSpeed;
    public Text txtMarcha;
    float fSpeed = 0;
    public Material materialFreno;

    private void Start() {

        wcFrontL = GameObject.Find("FrontL").GetComponent<WheelCollider>();
        wcFrontR = GameObject.Find("FrontL").GetComponent<WheelCollider>();
        wcBackL = GameObject.Find("FrontL").GetComponent<WheelCollider>();
        wcBackR = GameObject.Find("FrontL").GetComponent<WheelCollider>();

    }

    private void Update() {
        fSpeed = GetComponent<Rigidbody>().velocity.magnitude;
        txtSpeed.text = ((int)fSpeed).ToString();

        if (Input.GetKeyDown(KeyCode.F)) {

            frenoManoActivo = !frenoManoActivo;

            if (frenoManoActivo == true) {

                txtFrenoMano.text = "Handbrake: On";
            } else {
                txtFrenoMano.text = "Handbrake: Off";
            }
        }


    }




    private void FixedUpdate() {

        vPos = Input.GetAxis("Vertical");
        hPos = Input.GetAxis("Horizontal");

        wcFrontL.steerAngle = anguloMaxRotacion * hPos;
        wcFrontR.steerAngle = anguloMaxRotacion * hPos;


        if (!frenoManoActivo) {
            if (vPos > 0) {
                txtMarcha.text = "1";
                //desactiva luz freno
                materialFreno.DisableKeyword("_EMISSION");

                SoltarFreno();
                wcBackL.motorTorque = fuerzaMotor * vPos;
                wcBackR.motorTorque = fuerzaMotor * vPos;
            } else if (vPos < 0 && fSpeed>0.2) {
                materialFreno.EnableKeyword("_EMISSION");
                txtMarcha.text = "0";
                Frenar();
            }else if(vPos < 0 && fSpeed<=0.2) {
                SoltarFreno();
                txtMarcha.text = "R";
                wcBackL.motorTorque = fuerzaMotor * vPos;
                wcBackR.motorTorque = fuerzaMotor * vPos;
            }
        } else {
            wcBackL.brakeTorque = Mathf.Infinity;
            wcBackR.brakeTorque = Mathf.Infinity;
            wcFrontL.brakeTorque = Mathf.Infinity;
            wcFrontR.brakeTorque = Mathf.Infinity;
        } 
    }

        private void Frenar() {
            fuerzaMaxFrenado = fuerzaMaxFrenado + incrementoFrenada;
            wcFrontL.brakeTorque = fuerzaMaxFrenado;
            wcFrontR.brakeTorque = fuerzaMaxFrenado;
            wcBackL.brakeTorque = fuerzaMaxFrenado;
            wcBackR.brakeTorque = fuerzaMaxFrenado;
        }
        private void SoltarFreno() {
            wcFrontL.brakeTorque = 0;
            wcFrontR.brakeTorque = 0;
            wcBackL.brakeTorque = 0;
            wcBackR.brakeTorque = 0;
        }
    }

