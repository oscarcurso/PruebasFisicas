using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionScript : MonoBehaviour {


    public int speed =100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float vPos = Input.GetAxis("Vertical");
        float hPos = Input.GetAxis("Horizontal");
        //Avanzar sin pulsar nada
        GetComponent<CharacterController>().Move(
            transform.forward *
            Time.deltaTime *
            speed 
            );

        //rotamos avon hacia arriba y abajo

        transform.Rotate(new Vector3(vPos, hPos, hPos *-1));
       
	}
}
