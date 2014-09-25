using UnityEngine;
using System.Collections;

public class PowerUpDroppingBehavior : MonoBehaviour {
    //Se encarga de que el enemigo dropee powerups. Tira un dado para ver si corresponde
    public string powerUpName;
	public void DropPowerUp()
    {
        int chance = Random.Range(0, 6);
        if(chance >= 1)
        {
            //Debug.Log("Dropping powerup");
            GameObject powerUp = (GameObject)Resources.Load(powerUpName);
            SpeedPowerUpBehavior powerUpProjectile =  powerUp.GetComponent<SpeedPowerUpBehavior>();
            powerUpProjectile.owner = gameObject;
            powerUpProjectile.owner_tag = gameObject.tag;
            powerUpProjectile.direction = -1;
            Instantiate(powerUp, gameObject.transform.position, Quaternion.identity);
        }
    }
}
