using UnityEngine;
using System.Collections;

public class PlayerPowerUpGranterScript : MonoBehaviour {
    //Se encarga de dar o quitar al jugador los bonus apropiados
	void SpeedBonusGranter(float bonus)
    {
        Debug.Log("Granting Bonus");
        gameObject.GetComponent<RadialMovementScript>().speed += bonus;
        StartCoroutine(SpeedBonusReverter(bonus));

    }
    IEnumerator SpeedBonusReverter(float bonus)
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Revering Bonus");
        gameObject.GetComponent<RadialMovementScript>().speed -= bonus;
    }
}
