using UnityEngine;
using System.Collections;

public class PlayerPowerUpGranterScript : MonoBehaviour {
    //Se encarga de dar o quitar al jugador los bonus apropiados
	void SpeedBonusGranter(SpeedPowerUpBehavior.SpeedPowerUpMessage bonusMessage)
    {
        //Debug.Log("Granting Bonus");
        gameObject.GetComponent<RadialMovementScript>().speed += bonusMessage.bonus;
        StartCoroutine(SpeedBonusReverter(bonusMessage));

    }
    IEnumerator SpeedBonusReverter(SpeedPowerUpBehavior.SpeedPowerUpMessage bonusMessage)
    {
        yield return new WaitForSeconds(bonusMessage.time);
        //Debug.Log("Revering Bonus");
        gameObject.GetComponent<RadialMovementScript>().speed -= bonusMessage.bonus;
    }
    
}
