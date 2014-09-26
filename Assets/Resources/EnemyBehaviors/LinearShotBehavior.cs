using UnityEngine;
using System.Collections;

public class LinearShotBehavior : BaseShotBehavior {
    //Tipo de disparo lineal
    string tipo_disparo = "Bullets/EnemyBullet";
    GameObject disparo;
    
	// Use this for initialization
	void Start () {
        shotReady = true;
        disparo = (GameObject)Resources.Load(tipo_disparo);
        rateOfFire = 2f;
	}
	

    public override void Shot()
    {
            disparo.GetComponent<ForwardBulletMovementScript>().owner = gameObject;
            disparo.GetComponent<ForwardBulletMovementScript>().owner_tag = gameObject.tag;
            disparo.GetComponent<ForwardBulletMovementScript>().direction = -1;
            Instantiate(disparo, gameObject.transform.position, Quaternion.identity);
            Invoke("ReadyShot", rateOfFire);
            shotReady = false;
        
    }
    
}
