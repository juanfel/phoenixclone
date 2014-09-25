using UnityEngine;
using System.Collections;

public class PlayerPowerUpGranterScript : MonoBehaviour {
    //Se encarga de dar o quitar al jugador los bonus apropiados. Si obtiene uno brilla
	void SpeedBonusGranter(SpeedPowerUpBehavior.SpeedPowerUpMessage bonusMessage)
    {
        Debug.Log("Granting Bonus" + bonusMessage.bonus);
        GetComponent<RadialMovementScript>().speed += bonusMessage.bonus;
        GetComponent<RadialMovementScript>().updateSpeed(); 
        ((Behaviour)GetComponent("Halo")).enabled = true;
        StartCoroutine(SpeedBonusReverter(bonusMessage));

    }
    IEnumerator SpeedBonusReverter(SpeedPowerUpBehavior.SpeedPowerUpMessage bonusMessage)
    {
        yield return new WaitForSeconds(bonusMessage.time);
        //Debug.Log("Revering Bonus");
        ((Behaviour)GetComponent("Halo")).enabled = false;
        gameObject.GetComponent<RadialMovementScript>().speed -= bonusMessage.bonus;
        GetComponent<RadialMovementScript>().updateSpeed();
    }
    
}
