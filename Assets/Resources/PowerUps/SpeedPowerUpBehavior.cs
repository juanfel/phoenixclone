using UnityEngine;
using System.Collections;

public class SpeedPowerUpBehavior : EnemyBulletForwardBehavior {
    //Crea un powerup que aumenta la velocidad de la nave
    public float speedAugment;
    public float powerUpTime;
    RadialMovementScript player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    protected override void Hit(Collision coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            player = coll.gameObject.GetComponent<RadialMovementScript>();
            player.speed += speedAugment;
            Invoke("RevertChange", powerUpTime);
            
        }
    }
    void RevertChange()
    {
        if(player)
        {
            player.speed -= speedAugment;
        }
    }
}
