using UnityEngine;
using System.Collections;

public class ShootingAiBehavior : ZigZaggingAiBehavior {
    //Comportamiento para un enemigo que dispara. Por ahora hereda el movimiento zigzageante pero eso puede cambiar

    string tipo_disparo = "Bullets/EnemyBullet";
    GameObject disparo;
    bool shotReady = false;
    float rateOfFire = 1f;
    
    protected override void UpdateStatus()
    {
 	     base.UpdateStatus();
         if (shotReady)
         {
             disparo.GetComponent<ForwardBulletMovementScript>().owner = gameObject;
             disparo.GetComponent<ForwardBulletMovementScript>().direction = -1;
             Instantiate(disparo, gameObject.transform.position, Quaternion.identity);
             Invoke("ReadyShot", rateOfFire);
             shotReady = false;
         }
    }   
	void Start () {
        base.Init();
        disparo = (GameObject)Resources.Load(tipo_disparo);
	}
    public override void StartMovement()
    {
        //Hace que cuando de la orden de ataque tenga una chance de disparo
        base.StartMovement();
        int chance = Random.Range(0, 5);
        Debug.Log("Chance: " + chance);
        if(chance > 3)
        {
            ReadyShot();
        }
    }
	
	// Update is called once per frame
	void Update () {
        UpdateStatus();
	}
    void ReadyShot()
    {
        shotReady = true;
    }
}
