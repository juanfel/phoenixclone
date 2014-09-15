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
        Debug.Log("Bonustag: " + coll.gameObject.tag);
        if(coll.gameObject.tag == "Player")
        {
            Debug.Log("Sending Message");
            coll.gameObject.SendMessage("SpeedBonusGranter",speedAugment);
            KillMe();
            
        }
    }
}
