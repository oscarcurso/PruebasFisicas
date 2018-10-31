using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaScript : MonoBehaviour {


    [SerializeField] Transform genPoint;
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] int force = 100;
    [SerializeField] Transform ejeCanyon;
    private void Update() {



        if (Input.GetKeyDown(KeyCode.Space)) {

            GameObject proyectil = Instantiate(
                prefabProyectil,
                genPoint.transform.position,
                genPoint.transform.rotation
                );
            proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force);
        }
        float xR = Input.GetAxis("Vertical");
        float yR = Input.GetAxis("Horizontal");
        ejeCanyon.Rotate(xR * -1, yR, 0);
        ejeCanyon.Rotate(0, yR , 0);
    }
}