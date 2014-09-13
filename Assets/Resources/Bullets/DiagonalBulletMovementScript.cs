using UnityEngine;
using System.Collections;

public class DiagonalBulletMovementScript : ForwardBulletMovementScript {
    public bool moveLeft;
	// Use this for initialization
	
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
            Debug.Log("Moving Right");
            bullet.moveRight();
        }
    }
    public void setMoveLeft(bool setting)
    {
        //determina si este proyectil se va a mover de izquierda o derecha
        moveLeft = setting;
    }
	
}
