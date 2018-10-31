using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour {
    //[SerializeField] 
    [SerializeField] Transform target;
    Rigidbody miRigidbody;


    private void Start() {


        miRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {

        Vector3 distancia = target.position - transform.position;
        Vector3 distanciaNormalizada = distancia.normalized;
        Vector3 deltaPosition = distanciaNormalizada * Time.deltaTime;
        if (distancia.magnitude > 0.1f) {

            miRigidbody.MovePosition(miRigidbody.position + deltaPosition);
        }
    }


}
