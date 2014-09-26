using UnityEngine;
using System.Collections;

public abstract class BaseShotBehavior : MonoBehaviour {
    public bool shotReady;
    public bool fireOrder;
    protected float rateOfFire;
	// Use this for initialization
	void Start () {
        shotReady = true;
        fireOrder = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(shotReady && fireOrder)
        {
            Debug.Log("Shooting");
            Shot();
            
        }
        
	}
    public virtual void Shot()
    {

    }
    public virtual void ReadyShot()
    {
        //Se encarga de activar el tiro por efectos de cooldown
        shotReady = true;
    }
    public virtual void GiveFireOrder()
    {
        //Ve si la nave debe disparar por efectos de orden de ataque
        fireOrder = true;
    }
    public virtual void CancelFireOrder()
    {
        fireOrder = false;
    }
    public virtual void ToggleFireOrder()
    {
        Debug.Log("Toggling fireorder");
        fireOrder = !fireOrder;
    }
    
}
