using UnityEngine;
using System.Collections;

public class ShootingAiBehavior : ZigZaggingAiBehavior {
    //Comportamiento para un enemigo que dispara. Por ahora hereda el movimiento zigzageante pero eso puede cambiar

    public BaseShotBehavior shootBehavior;
    bool startedShooting;
    void StartShooting()
    {
        int chance = Random.Range(0, 6);
        //Debug.Log("Chance: " + chance);
        if (chance > 3)
        {
            shootBehavior.ToggleFireOrder();

        }
        startedShooting = false;
    }
    protected override void UpdateStatus()
    {
 	     base.UpdateStatus();
        if(!startedShooting)
        {
            Invoke("StartShooting", 4f);
            startedShooting = true;
        }
         
        
    }   
	void Start () {
        base.Init();
        startedShooting = false;
       
        
	}
    public override void StartMovement()
    {
        //Hace que cuando de la orden de ataque tenga una chance de disparo
        base.StartMovement();
    }
	
	
}
