using UnityEngine;
using System.Collections;

public class ZigZaggingAiBehavior : MonoBehaviour {
    public RadialMovementScript radialMovement;
    bool startedMovement = true;
    bool startedReturn;
    bool oscilating = false;
    bool movingLeft = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Se mueve en un patron zigzageante cuando se le ordena hacerlo
        //Incluye el patron de retorno
        if (startedMovement)
        {
            if (!oscilating)
            {
                InvokeRepeating("changeDirection", 1f, 0.5f);
                oscilating = true;
            }
            if (movingLeft)
            {
                radialMovement.moveLeft();
            }
            else
            {
                radialMovement.moveRight();
            }
            radialMovement.moveForward(-1f);
        }
        
	}

    void changeDirection()
    {
        //Cambia la direccion del enemigo despues de un tiempo determinado
        movingLeft = !movingLeft; //Deberia cambiar de true a false y viceversa
    }
}
