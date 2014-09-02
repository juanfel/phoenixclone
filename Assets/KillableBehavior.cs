using UnityEngine;
using System.Collections;

public class KillableBehavior : MonoBehaviour {
    public int hitpoints;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void RemoveHitpoint()
    {
        hitpoints--;
        if (hitpoints <= 0)
        {
            KillMe();
        }
    }
    void KillMe()
    {
        //Mata a este gameObject
        Destroy(gameObject);
    }
}
