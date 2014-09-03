using UnityEngine;
using System.Collections;

public class KillableBehavior : MonoBehaviour {
    //Behavior para que naves tengan hitpoints y puedan morir
    public int hitpoints;
    public int score;
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
    public void RemoveHitpoint(int damage, GameObject attacker)
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
            KillMe(attacker);
        }
    }
    void KillMe(GameObject attacker)
    {
        //Mata a este gameObject y si es pertinente 
        //da el puntaje necesario al atacante
        if (attacker.tag == "Player")
        {
            attacker.GetComponent<ScorableBehavior>().addScore(score);
        }
        Destroy(gameObject);
    }
}
