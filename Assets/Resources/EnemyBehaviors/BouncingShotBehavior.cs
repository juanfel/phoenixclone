using UnityEngine;
using System.Collections;

public class BouncingShotBehavior : BaseShotBehavior {
    //Dispara balas rebotantes
    string tipo_disparo = "Bullets/BouncingEnemyBullet";
    GameObject disparo;
    BouncingBulletMovementScript currentShot;
    float rateOfFire = 2f;
    // Use this for initialization
    void Start()
    {
        disparo = (GameObject)Resources.Load(tipo_disparo);
    }


    public override void Shot()
    {
        if(shotReady)
        {
            currentShot = disparo.GetComponent<BouncingBulletMovementScript>();

            currentShot.owner = gameObject;
            currentShot.owner_tag = gameObject.tag;
            currentShot.direction = -1;
            int chance = Random.Range(0, 10);
            if (chance > 5)
                currentShot.setMoveLeft(true);
            else
                currentShot.setMoveLeft(false);
            Instantiate(disparo, gameObject.transform.position, Quaternion.identity);
            Invoke("ReadyShot", rateOfFire);
            shotReady = false;
        }
        
    }
}
