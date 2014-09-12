using UnityEngine;
using System.Collections;

public class ShootingAiBehavior : ZigZaggingAiBehavior {
    //Comportamiento para un enemigo que dispara. Por ahora hereda el movimiento zigzageante pero eso puede cambiar

    string shootTipe = "Bala";
    GameObject projectile;
	void Start () {
        base.Init();
	}
	
	// Update is called once per frame
	void Update () {
        base.UpdateStatus();
	}
}
