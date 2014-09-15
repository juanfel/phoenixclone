using UnityEngine;
using System.Collections;

public class PowerUpDroppingBehavior : MonoBehaviour {
    //Se encarga de que el enemigo dropee powerups. Tira un dado para ver si corresponde
    public string powerUpName;
	public void DropPowerUp()
    {
        int chance = Random.Range(0, 6);
        if(chance > 4)
        {
            GameObject powerUp = (GameObject)Resources.Load(powerUpName);
            Instantiate(powerUp);
        }
    }
}
