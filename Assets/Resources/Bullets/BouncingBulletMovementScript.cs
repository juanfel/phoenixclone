using UnityEngine;
using System.Collections;

public class BouncingBulletMovementScript : DiagonalBulletMovementScript {

    protected override void Hit(Collision coll)
    {
        //Esta bala debe chocar con cualquier enemigo y cambiar su direccion si eso ocurre
        if(coll.gameObject.tag != "player")
        {
            setMoveLeft(!moveLeft);
        }
        base.Hit(coll);
    }
}
