using UnityEngine;
using System.Collections;

public class ShieldBehaviorScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision coll)
    {
        //Evita que colisione con el que creo el escudo
        if(transform.parent.tag == coll.gameObject.tag)
        {
            Physics.IgnoreCollision(transform.collider, coll.collider);
        }
        else
        {
            //Hace que cualquier otra entidad no pueda tocar al jugador hasta que salga
            Physics.IgnoreCollision(transform.parent.collider, coll.collider,true);
        }
    }
    void OnCollisionExit(Collision coll)
    {
        //Recupera la collision entre el jugador y quien sea que toco el shield
        if (transform.parent.tag != coll.gameObject.tag)
        {
            Physics.IgnoreCollision(transform.parent.collider, coll.collider,false);
        }
    }
}
