using UnityEngine;
using System.Collections;

public class FiringBehaviorScript : MonoBehaviour {
    GameObject disparo;
    string tipo_disparo = "Bullets/Bala";
    bool shotReady = true;
    public float rateOfFire; //En segundos
	// Use this for initialization
	void Start () {
        disparo = (GameObject)Resources.Load(tipo_disparo);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && shotReady)
        {
            disparo.GetComponent<ForwardBulletMovementScript>().owner = gameObject;
            Instantiate(disparo, gameObject.transform.position, Quaternion.identity);
            Invoke("ReadyShot", rateOfFire);
            shotReady = false;
        }
      

	}
    void ReadyShot()
    {
        shotReady = true;
    }
    void shot()
    {

    }
    
}
