using UnityEngine;
using System.Collections;

public class FiringBehaviorScript : MonoBehaviour {
    GameObject disparo;
    string tipo_disparo = "Bala";
	// Use this for initialization
	void Start () {
        disparo = (GameObject)Resources.Load(tipo_disparo);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(disparo, gameObject.transform.position, Quaternion.identity);
        }
	}
    void shot()
    {

    }
}
