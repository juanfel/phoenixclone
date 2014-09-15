using UnityEngine;
using System.Collections;

public class SpeedPowerUpBehavior : ForwardBulletMovementScript {
    //Crea un powerup que aumenta la velocidad de la nave
    public float speedAugment;
    public float powerUpTime;
    RadialMovementScript player;
    protected override bool CheckBoundaries()
    {
        return base.CheckBoundaries() || transform.position.z == 0;
    }
    protected override void Hit(Collision coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            player = coll.gameObject.GetComponent<RadialMovementScript>();
            player.speed += speedAugment;
            Invoke("RevertChange", powerUpTime);
            KillMe();
            
        }
    }
    void RevertChange()
    {
        if(player)
        {
            Debug.Log("Reverting");
            player.speed -= speedAugment;
        }
    }
}
