using UnityEngine;
using System.Collections;

public class VShapedShotBehavior : BaseShotBehavior {
    //Tipo de disparo en forma de V
    string tipo_disparo = "Bullets/DiagonalEnemyBullet";
    GameObject shot;
    GameObject[] currentShots;
    float rateOfFire = 2f;
	// Use this for initialization
	void Start () {
        currentShots = new GameObject[2];
        shot = (GameObject)Resources.Load(tipo_disparo);
        
	}

    public override void Shot()
    {
        for (int i = 0; i < 2; i++ )
        {
            currentShots[i] = (GameObject)Instantiate(shot, gameObject.transform.position, Quaternion.identity);
        }
        foreach (GameObject disparo in currentShots)
        {

                DiagonalBulletMovementScript diagScript = disparo.GetComponent<DiagonalBulletMovementScript>();
                diagScript.owner = gameObject;
                diagScript.owner_tag = tag;
                diagScript.direction = -1;
                diagScript.setMoveLeft(true);
        }
        currentShots[1].GetComponent<DiagonalBulletMovementScript>().setMoveLeft(false);
        
        
        Invoke("ReadyShot", rateOfFire);
        shotReady = false;
    }
}
