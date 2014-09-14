using UnityEngine;
using System.Collections;

public class KillableBehavior : MonoBehaviour {
    //Behavior para que naves tengan hitpoints y puedan morir
    public int hitpoints;
    public int score;
    public bool ghostAfterHit;
    bool gameOver = false;
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
    public virtual void RemoveHitpointByMessage(HitMessage hit)
    {
        //Para cuando se usan mensajes para marcar un hit
        RemoveHitpoint(hit.damage, hit.attacker);
    }
    public virtual void RemoveHitpoint(int damage, GameObject attacker)
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
    protected void KillMe(GameObject attacker)
    {
        //Mata a este gameObject y si es pertinente 
        //da el puntaje necesario al atacante
        Debug.Log("attacker: " + attacker.tag);
        if (attacker.tag == "Player")
        {
            attacker.GetComponent<ScorableBehavior>().addScore(score);
        }
        if (gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerGameOverScript>().StartGameOver();
        }
        Destroy(gameObject);
   
        
    }
    public struct HitMessage
    {
        //Struct que se ocupa para mandar mensajes de daño al KillableBehavior
        public int damage;
        public GameObject attacker;
        public HitMessage(int damage, GameObject attacker)
        {
            this.damage = damage;
            this.attacker = attacker;

        }
    }
    
}
