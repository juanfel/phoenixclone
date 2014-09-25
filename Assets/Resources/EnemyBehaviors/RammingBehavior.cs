using UnityEngine;
using System.Collections;

public class RammingBehavior : MonoBehaviour {
    //Comportamiento para aquellas naves que pueden embestir al jugador
    public int damage = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void ReactivateCollider()
    {
        gameObject.collider.enabled = true;
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //Debug.Log("Embestida");
            KillableBehavior.HitMessage hit = new KillableBehavior.HitMessage(damage, gameObject);
            coll.gameObject.SendMessage("RemoveHitpointByMessage", hit,SendMessageOptions.DontRequireReceiver);
            
        }
        

    }
}
