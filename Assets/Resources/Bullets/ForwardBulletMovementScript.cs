using UnityEngine;
using System.Collections;

public class ForwardBulletMovementScript : MonoBehaviour {
    //Controla el movimiento de una bala y su comportamiento cuando
    //choca
    public int direction = 1; //Indica el eje de movimiento (hacia adelante-hacia atras)
    public int damage = 1;
    public GameObject owner;
    public string owner_tag;
    public RadialMovementScript bullet;
	// Use this for initialization
	void Start () {
        bullet.position.z = owner.transform.position.z;
        bullet.theta = owner.GetComponent<RadialMovementScript>().theta;
        bullet.updatePosition();
	}
	
    protected virtual bool CheckBoundaries()
    {
        //Ve si la bala esta dentro del campo de juego
        return gameObject.GetComponent<RadialMovementScript>().max_distance == gameObject.transform.position.z;
    }
	// Update is called once per frame
	void FixedUpdate () {
        MovementUpdate();
        if (CheckBoundaries())
        {
            KillMe();
        }
	}
    void OnCollisionEnter(Collision coll)
    {
        //Debug.Log("Owner: " + owner_tag);
        //Debug.Log("Receiver: " + coll.gameObject.tag);
        if (HitConditions(coll))
        {
            Hit(coll);
        }
        
    }
    protected virtual bool HitConditions(Collision coll)
    {
        //Contiene lo que se considera como colision
        return coll != null && coll.gameObject.tag != owner_tag;
    }
    protected virtual void MovementUpdate()
    {
        //Contiene el comportamiento del movimiento
        bullet.moveForward(direction);
    }
    protected virtual void Hit(Collision coll)
    {
        //Contiene el comportamiento cuando el proyectil golpea a alguien
        KillableBehavior.HitMessage hit = new KillableBehavior.HitMessage(damage, owner.gameObject);
        coll.gameObject.SendMessage("RemoveHitpointByMessage", hit, SendMessageOptions.DontRequireReceiver);
        Invoke("KillMe", 0.1f);
    }
    protected void KillMe()
    {
        Destroy(gameObject);
    }
}
