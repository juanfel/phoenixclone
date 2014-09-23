using UnityEngine;
using System.Collections;

public class KillableBehavior : MonoBehaviour {
    //Behavior para que naves tengan hitpoints y puedan morir
    public int hitpoints;
    public int score;
    public bool ghostAfterHit;
    public bool hasPowerUp = false;

    public PowerUpDroppingBehavior powerUpDropper;
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
        //Se encarga de eliminar limpiamente a la entidad que puede ser matada
        //Incluye mandar a aumentar puntos, mandar a gameover, quitarse a si mismo de la lista del wave y
        //soltar powerups
       
        if(attacker != null && attacker.tag == "Player")
        {
            attacker.GetComponent<ScorableBehavior>().addScore(score);
        }
        if (gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerGameOverScript>().StartGameOver();
        }
        if(hasPowerUp)
        {
            powerUpDropper.DropPowerUp();
        }
        if(transform.parent != null && transform.parent.tag == "WaveManager")
        {
            EnemyAIBehavior currentAIBehavior = GetComponent<EnemyAIBehavior>();
            GetComponentInParent<WaveManagerScript>().GetEnemyList().Remove(currentAIBehavior);
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
