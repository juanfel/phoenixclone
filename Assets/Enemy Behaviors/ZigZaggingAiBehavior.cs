using UnityEngine;
using System.Collections;

public class ZigZaggingAiBehavior : MonoBehaviour {
    public RadialMovementScript radialMovement;
    bool startedMovement = true;
    bool startedReturn;
    bool movingLeft = true;
    bool timetoChangeDirection = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Se mueve en un patron zigzageante cuando se le ordena hacerlo
        //Incluye el patron de retorno
        if (startedMovement)
        {
            if (timetoChangeDirection)
            {
                Invoke("changeDirection", 1f); //Que cambie direccion cada 1 segundo
                timetoChangeDirection = false;
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
        timetoChangeDirection = true;
    }
}
