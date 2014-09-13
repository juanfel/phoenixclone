using UnityEngine;
using System.Collections;

public class ShootingAiBehavior : ZigZaggingAiBehavior {
    //Comportamiento para un enemigo que dispara. Por ahora hereda el movimiento zigzageante pero eso puede cambiar

    public BaseShotBehavior shootBehavior;
    
    protected override void UpdateStatus()
    {
 	     base.UpdateStatus();
    }   
	void Start () {
        base.Init();
       
	}
    public override void StartMovement()
    {
        //Hace que cuando de la orden de ataque tenga una chance de disparo
        base.StartMovement();
        int chance = Random.Range(0, 6);
        Debug.Log("Chance: " + chance);
        if(chance > 2)
        {
            shootBehavior.Shot();
        }
    }
	
	// Update is called once per frame
	void Update () {
        UpdateStatus();
	}
   
}
