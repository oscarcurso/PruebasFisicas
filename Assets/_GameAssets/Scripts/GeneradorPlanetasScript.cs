using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPlanetasScript : MonoBehaviour {

    public GameObject[] prefabsPlaneta;
    public Transform tX0Y0Z0;
    public Transform tX1;
    public Transform tY1;
    public Transform tZ1;
    public int numeroPlanetas;


    private void Start() 
        {
        for (int i= 0; i < numeroPlanetas; i++) 
            {

            GenerarPlaneta();
            }
        }

    private void GenerarPlaneta() 
        {
        float x = Random.Range(tX0Y0Z0.position.x, tX1.position.x);
        float y = Random.Range(tX0Y0Z0.position.y, tY1.position.y);
        float z = Random.Range(tX0Y0Z0.position.z, tZ1.position.z);

        int posicionAleatoria = Random.Range(0, prefabsPlaneta.Length);
        GameObject planeta = Instantiate(prefabsPlaneta[posicionAleatoria]);
        planeta.transform.position = new Vector3(x, z, y);
        }
}
