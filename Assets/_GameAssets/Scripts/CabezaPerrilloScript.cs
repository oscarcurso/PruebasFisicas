using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabezaPerrilloScript : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter(Collider other) {
        print("CAbeza perrillo trigger enter: " + gameObject.name);
    }
}
