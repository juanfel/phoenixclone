using UnityEngine;
using System.Collections;

public class SpeedPowerUpBehavior : ForwardBulletMovementScript
{
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
        //Debug.Log("Bonustag: " + coll.gameObject.tag);
        if (coll.gameObject.tag == "Player")
        {
            //Debug.Log("Sending Message");
            SpeedPowerUpMessage message = new SpeedPowerUpMessage(speedAugment, powerUpTime);
            coll.gameObject.SendMessage("SpeedBonusGranter", message);
            KillMe();

        }
    }
    public class SpeedPowerUpMessage
    {
        //Tipo de mensaje con el contenido del bonus
        public float bonus;
        public float time;
        public SpeedPowerUpMessage(float bonus, float time)
        {
            this.bonus = bonus;
            this.time = time;
        }

    }
}
