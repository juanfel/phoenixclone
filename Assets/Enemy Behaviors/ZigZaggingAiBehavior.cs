using UnityEngine;
using System.Collections;

public class ZigZaggingAiBehavior : MonoBehaviour {
    public RadialMovementScript radialMovement;
    bool startedMovement = true;
    bool startedReturn;
    bool oscilating = false;
    bool movingLeft = false;
    float originalTheta;
    public float movementAmplitude = 0.15f; //Amplitud del movimiento zigzageante en porciones de circulo
	// Use this for initialization
	void Start () {
        originalTheta = radialMovement.theta;
	}
	
	// Update is called once per frame
	void Update () {
        //Se mueve en un patron zigzageante cuando se le ordena hacerlo
        //Incluye el patron de retorno
        if (startedMovement)
        {
            changeDirection();
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
        //Cambia la direccion del enemigo de acuerdo a la distancia angular
        //recorrida
        if (Mathf.Abs(originalTheta - radialMovement.theta) >=(movementAmplitude*(2*Mathf.PI)))
        {
            movingLeft = !movingLeft; //Deberia cambiar de true a false y viceversa
            originalTheta = radialMovement.theta;
        }
        

    }
}
