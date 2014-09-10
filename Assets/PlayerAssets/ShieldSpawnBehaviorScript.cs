using UnityEngine;
using System.Collections;

public class ShieldSpawnBehaviorScript : MonoBehaviour {
    //Se encarga de crear el escudo del jugador
    //Eventualmente esto se puede separar en 2 clases si fuese necesario
    GameObject shield;
    GameObject currentShield = null;
    public float activationTime;
    bool activated;
	// Use this for initialization
	void Start () {
        shield = (GameObject)Resources.Load("Shield");
        activated = false;
	}
	// Update is called once per frame
	void Update () {
        if (currentShield)
        {
            //gameObject es el objeto dueño del escudo. Deberia cambiar esto.
            currentShield.transform.position = gameObject.transform.position; 
        }
	    if(Input.GetButtonDown("Fire2"))
        {
            createShield();
        }
	}
    void createShield()
    {
        if (!activated)
        {
            currentShield = (GameObject)Instantiate(shield);
            currentShield.transform.parent = transform;
            activated = true;
            Invoke("deactivateShield", activationTime);
        }
        

    }
    void deactivateShield()
    {
        activated = false;
        if (currentShield)
        {
            Destroy(currentShield);
            currentShield = null;
        }
    }
}
