using UnityEngine;
using System.Collections;

public class ForwardBulletMovementScript : MonoBehaviour {
    public RadialMovementScript bullet;
	// Use this for initialization
	void Start () {
        bullet.position.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
        bullet.moveForward();
	}
}
