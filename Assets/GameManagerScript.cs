using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
    //Se encarga de instanciar las distintas waves
	// Use this for initialization
    string waveName = "EnemyWaveManager";
    public GameObject waveManager;
    GameObject currentWaveManager;
    public int childcount;
	void Start () {
        waveManager = Resources.Load<GameObject>("EnemyBehaviors/" + waveName);
        currentWaveManager = (GameObject)Instantiate(waveManager);
        currentWaveManager.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
        childcount = waveManager.transform.childCount;
        if (waveManager && currentWaveManager.transform.childCount == 0)
        {
            Destroy(currentWaveManager);
            currentWaveManager = (GameObject)Instantiate(waveManager);
        }

	}
}
