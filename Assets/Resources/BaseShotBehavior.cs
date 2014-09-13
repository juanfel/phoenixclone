using UnityEngine;
using System.Collections;

public abstract class BaseShotBehavior : MonoBehaviour {
    public bool shotReady;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(shotReady)
        {
            Shot();
        }
	}
    public virtual void Shot()
    {

    }
    public virtual void ReadyShot()
    {
        shotReady = true;
    }
    
}
