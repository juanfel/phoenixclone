using UnityEngine;
using System.Collections;

public class DiagonalBulletMovementScript : ForwardBulletMovementScript {
    public bool moveLeft = false;
	// Use this for initialization
	void Start () {
	
	}
    protected override bool CheckBoundaries()
    {
        return base.CheckBoundaries() || transform.position.z == 0;
    }
    protected override void MovementUpdate()
    {
        base.MovementUpdate();
        if(moveLeft)
        {
            bullet.moveLeft();
        }
        else
        {
            bullet.moveRight();
        }
    } 
	// Update is called once per frame
	void Update () {
	
	}
}
