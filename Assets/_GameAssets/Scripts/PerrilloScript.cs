using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerrilloScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {

        print("Viva el Trigger: " + gameObject.name);
    }
}
