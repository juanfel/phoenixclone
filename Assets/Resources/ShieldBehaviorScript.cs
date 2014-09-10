using UnityEngine;
using System.Collections;

public class ShieldBehaviorScript : MonoBehaviour {
	// Use this for initialization
	void Awake () {
       
	}
	
	// Update is called once per frame
    void Update()
    {
        if (transform.parent.collider.enabled)
        {
            transform.parent.collider.enabled = false;
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        //Evita que colisione con el que creo el escudo
        if(transform.parent.tag == coll.gameObject.tag)
        {
            Physics.IgnoreCollision(transform.collider, coll.collider);
        }
        
    }
    void OnDestroy()
    {
        transform.parent.collider.enabled = true;
    }
    
}
