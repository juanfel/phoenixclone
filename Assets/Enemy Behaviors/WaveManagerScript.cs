using UnityEngine;
using System.Collections;

public class WaveManagerScript : MonoBehaviour {
    //Se encarga de monitorear el comportamiento de todas las naves de una wave
    //dandoles las instrucciones para moverse adelante o no
	// Use this for initialization
    bool attackOrder = false;
    bool invokedAttack = false;
    public GameObject player;

    float spawnTime;
    const float MAXSPAWNTIME = 10f;
 
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //Se quiere que el manager de una orden de ataque aleatoria a un conjunto arbitrario
        //de naves en un tiempo arbitrario
        if(!invokedAttack)
        {
            spawnTime = Random.Range(5,MAXSPAWNTIME);
            Invoke("GiveAttackOrder",spawnTime);
            invokedAttack = true;
        }
        if (attackOrder)
        {
            foreach (Transform enemy in transform)
            {
                enemy.gameObject.GetComponent<ZigZaggingAiBehavior>().SetTarget(player);
                enemy.gameObject.GetComponent<ZigZaggingAiBehavior>().StartMovement();
                //StartCoroutine(StartMovement(enemy.gameObject));

            }
            attackOrder = false ;
        }
        
	}
    void GiveAttackOrder()
    {
        Debug.Log("ATTACK!");
        attackOrder = true;
        invokedAttack = false;
    }
    IEnumerator StartMovement(GameObject enemy)
    {
        //Empieza a mover a los hijos dentro del rango dado
        yield return new WaitForSeconds(Random.Range(0, 4));
        enemy.gameObject.GetComponent<EnemyAIBehavior>().StartMovement();
    }
}
