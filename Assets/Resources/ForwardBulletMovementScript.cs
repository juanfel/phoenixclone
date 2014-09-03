using UnityEngine;
using System.Collections;

public class ForwardBulletMovementScript : MonoBehaviour {
    //Controla el movimiento de una bala y su comportamiento cuando
    //choca
    int direction = 1; //Indica el eje de movimiento (hacia adelante-hacia atras)
    public int damage = 1;
    public GameObject owner;
    public RadialMovementScript bullet;
	// Use this for initialization
	void Start () {
        bullet.position.z = owner.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        bullet.moveForward(direction);
	}
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag != owner.tag)
        {
            Debug.Log("HIT! Owner:" + owner.tag);
            Debug.Log("coll:" + coll.gameObject.tag);
            coll.gameObject.GetComponent<KillableBehavior>().RemoveHitpoint(damage,coll.gameObject);
            
        }
        
    }
}
