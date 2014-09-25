using UnityEngine;
using System.Collections;

public class BouncingBulletMovementScript : DiagonalBulletMovementScript {

    protected override void Hit(Collision coll)
    {
        //Esta bala debe chocar con cualquier enemigo y cambiar su direccion si eso ocurre
        if(coll.gameObject.tag != "Player")
        {
            //Debug.Log("Change of direction");
            moveLeft = !moveLeft;
        }
        else
        {
            base.Hit(coll);
        }
        
    }
    protected override bool HitConditions(Collision coll)
    {
        //Considera si ambas cosas son del mismo tipo pero diferentes 
        return coll != null && coll.gameObject != gameObject;
    }
}
