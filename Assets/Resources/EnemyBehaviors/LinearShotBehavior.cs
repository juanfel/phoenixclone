using UnityEngine;
using System.Collections;

public class LinearShotBehavior : BaseShotBehavior {
    //Tipo de disparo lineal
    string tipo_disparo = "Bullets/EnemyBullet";
    GameObject disparo;
    float rateOfFire = 2f;
	// Use this for initialization
	void Start () {
        disparo = (GameObject)Resources.Load(tipo_disparo);
	}
	

    public override void Shot()
    {
        if(shotReady)
        {
            disparo.GetComponent<ForwardBulletMovementScript>().owner = gameObject;
            disparo.GetComponent<ForwardBulletMovementScript>().owner_tag = gameObject.tag;
            disparo.GetComponent<ForwardBulletMovementScript>().direction = -1;
            Instantiate(disparo, gameObject.transform.position, Quaternion.identity);
            Invoke("ReadyShot", rateOfFire);
            shotReady = false;
        }
        
    }
    
}
