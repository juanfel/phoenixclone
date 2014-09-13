using UnityEngine;
using System.Collections;

public class EnemyBulletForwardBehavior : ForwardBulletMovementScript {

	// Use this for initialization
	void Start () {
	
	}

    protected override bool CheckBoundaries()
    {
        return base.CheckBoundaries() || transform.position.z == 0;
    }
}
