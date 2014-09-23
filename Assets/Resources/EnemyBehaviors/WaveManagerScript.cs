using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WaveManagerScript : MonoBehaviour {
    //Se encarga de monitorear el comportamiento de todas las naves de una wave
    //dandoles las instrucciones para moverse adelante o no
	// Use this for initialization
    bool attackOrder = false;
    bool invokedAttack = false;
    public GameObject player;
    List<EnemyAIBehavior> itemsForRandomEnable;

    float spawnTime;
    const float MAXSPAWNTIME = 4f;
 
	void Start () {
        itemsForRandomEnable = new List<EnemyAIBehavior>();
        player = GameObject.FindGameObjectWithTag("Player");
        foreach (Transform child in transform)
        {
            itemsForRandomEnable.Add(child.gameObject.GetComponent<EnemyAIBehavior>());
            child.gameObject.GetComponent<EnemyAIBehavior>().waveManager = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //Se quiere que el manager de una orden de ataque aleatoria a un conjunto arbitrario
        //de naves en un tiempo arbitrario
        if(!invokedAttack)
        {
            spawnTime = Random.Range(0,MAXSPAWNTIME);
            Invoke("GiveAttackOrder",spawnTime);
            invokedAttack = true;
        }
        if (attackOrder)
        {
            GiveRandomAttackOrder();
            attackOrder = false ;
        }
        
	}
    void GiveRandomAttackOrder()
    {
        //Da una orden de ataque a un grupo aleatorio de enemigos
        int count = itemsForRandomEnable.Count;
        Shuffle<EnemyAIBehavior>(itemsForRandomEnable);
        if (itemsForRandomEnable != null && count > 0)
        {
            int itemId = new System.Random().Next(itemsForRandomEnable.Count);
            
            for (int i = 0; i < itemsForRandomEnable.Count; i++)
            {
                itemsForRandomEnable[i].SetTarget(player);
                if (i == itemId) { itemsForRandomEnable[i].StartMovement(); }
               
            }

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
    public IList<EnemyAIBehavior> GetEnemyList()
    {
        return itemsForRandomEnable;
    }
    //Funciones de utilidad para seleccion aleatoria de naves
    public static void Shuffle<T>(List<T> list)
    {
        for (var i = 0; i < list.Count; i++)
            Swap(list,i, Random.Range(i, list.Count));
    }

    public static void Swap<T>(List<T> list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
