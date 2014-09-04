using UnityEngine;
using System.Collections;

public class WaveManagerScript : MonoBehaviour {
    //Se encarga de monitorear el comportamiento de todas las naves de una wave
    //dandoles las instrucciones para moverse adelante o no
	// Use this for initialization
    bool attackOrder = true;
    public GameObject player;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (attackOrder)
        {
            foreach (Transform enemy in transform)
            {
                enemy.gameObject.GetComponent<ZigZaggingAiBehavior>().target = player;
                StartCoroutine(StartMovement(enemy.gameObject));

            }
            attackOrder = !attackOrder;
        }
        
	}
    IEnumerator StartMovement(GameObject enemy)
    {
        //Empieza a mover a los hijos dentro del rango dado
        yield return new WaitForSeconds(Random.Range(0, 4));
        enemy.gameObject.GetComponent<EnemyAIBehavior>().StartMovement();
    }
}
