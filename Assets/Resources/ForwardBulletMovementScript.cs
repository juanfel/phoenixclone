using UnityEngine;
using System.Collections;

public class ForwardBulletMovementScript : MonoBehaviour {
    //Controla el movimiento de una bala y su comportamiento cuando
    //choca
    public int direction = 1; //Indica el eje de movimiento (hacia adelante-hacia atras)
    public int damage = 1;
    public GameObject owner;
    public RadialMovementScript bullet;
	// Use this for initialization
	void Start () {
        bullet.position.z = owner.transform.position.z;
	}
	
    protected virtual bool CheckBoundaries()
    {
        //Ve si la bala esta dentro del campo de juego
        return gameObject.GetComponent<RadialMovementScript>().max_distance == gameObject.transform.position.z;
    }
	// Update is called once per frame
	void Update () {
        bullet.moveForward(direction);
        if (CheckBoundaries())
        {
            KillMe();
        }
	}
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag != owner.tag)
        {
            Debug.Log("HIT! Owner:" + owner.tag);
            Debug.Log("coll:" + coll.gameObject.tag);
            KillableBehavior.HitMessage hit = new KillableBehavior.HitMessage(damage, owner.gameObject);
            coll.gameObject.SendMessage("RemoveHitpointByMessage", hit,SendMessageOptions.DontRequireReceiver);
            Invoke("KillMe", 0.1f) ;
        }
        
    }
    void KillMe()
    {
        Destroy(gameObject);
    }
}
