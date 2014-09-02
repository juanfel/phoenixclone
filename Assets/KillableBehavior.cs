using UnityEngine;
using System.Collections;

public class KillableBehavior : MonoBehaviour {
    //Behavior para que naves tengan hitpoints y puedan morir
    public int hitpoints;
    public bool ghostAfterHit;
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
    public void RemoveHitpoint(int damage)
    {
        hitpoints -= damage;
        //Queremos que lo que sea que haga daño lo haga una sola vez
        //por lo que se quita el hitbox del dueño durante un tiempo
        //(solo si esta activado este tipo de comportamiento)
        if (ghostAfterHit)
        {
            gameObject.collider.enabled = false;
            Invoke("ReactivateCollider", 4f);
        }
        if (hitpoints <= 0)
        {
            KillMe();
        }
    }
    void KillMe()
    {
        //Mata a este gameObject
        Destroy(gameObject);
    }
}
