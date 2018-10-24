using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoMovilScript : MonoBehaviour {

    public float fuerzaMaxFrenado = 10;
    float anguloMaxRotacion = 20;
    private float vPos;
    float hPos;
    private WheelCollider wcFrontL, wcFrontR, wcBackL, wcBackR;
    public float fuerzaMotor = 100;
    public float incrementoFrenada = 10;
    //private float fuerzaMaxFrenado = 0;

    private void Start() {

        wcFrontL = GameObject.Find("FrontL").GetComponent<WheelCollider>();
        wcFrontR = GameObject.Find("FrontL").GetComponent<WheelCollider>();
        wcBackL = GameObject.Find("FrontL").GetComponent<WheelCollider>();
        wcBackR = GameObject.Find("FrontL").GetComponent<WheelCollider>();

    }




    private void FixedUpdate() {

        vPos = Input.GetAxis("Vertical");
        hPos = Input.GetAxis("Horizontal");
        if (vPos > 0) {
            SoltarFreno();

            wcBackL.motorTorque = fuerzaMotor * vPos;
            wcBackR.motorTorque = fuerzaMotor * vPos;

        }else if (vPos < 0) {
            Frenar();
        }

        wcFrontL.steerAngle = anguloMaxRotacion * hPos;
        wcFrontR.steerAngle = anguloMaxRotacion * hPos;

    }

    private void Frenar() {
        fuerzaMaxFrenado = fuerzaMaxFrenado + incrementoFrenada;
        wcFrontL.brakeTorque = fuerzaMaxFrenado;
        wcFrontR.brakeTorque = fuerzaMaxFrenado;
        wcBackL.brakeTorque = fuerzaMaxFrenado;
        wcBackR.brakeTorque = fuerzaMaxFrenado;

    }
    private void SoltarFreno() {


    }
}
