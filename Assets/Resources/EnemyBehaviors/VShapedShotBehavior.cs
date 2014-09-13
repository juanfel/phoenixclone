using UnityEngine;
using System.Collections;

public class VShapedShotBehavior : BaseShotBehavior {
    //Tipo de disparo en forma de V
    string tipo_disparo = "Bullets/DiagonalEnemyBullet";
    GameObject[] disparos;
    float rateOfFire = 2f;
	// Use this for initialization
	void Start () {
        disparos = new GameObject[2];
        for (int i = 0; i < 2; i++)
        {
            disparos[i] = (GameObject)Resources.Load(tipo_disparo);
        }
	}

    public override void Shot()
    {
        foreach(GameObject disparo in disparos)
        {
            DiagonalBulletMovementScript diagScript = disparo.GetComponent<DiagonalBulletMovementScript>();
            diagScript.owner = gameObject;
            diagScript.direction = -1;
        }
        disparos[0].GetComponent<DiagonalBulletMovementScript>().moveLeft = true;
        foreach(GameObject disparo in disparos)
        {
            Instantiate(disparo, gameObject.transform.position, Quaternion.identity);
        }
        
        Invoke("ReadyShot", rateOfFire);
        shotReady = false;
    }
}
