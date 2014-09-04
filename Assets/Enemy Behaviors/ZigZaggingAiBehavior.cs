﻿using UnityEngine;
using System.Collections;

public class ZigZaggingAiBehavior : MonoBehaviour {
    public RadialMovementScript radialMovement;
    public RadialMovementScript playerRadialMovement;
    bool startedGameplay = false;
    bool startedMovement = true;
    bool startedReturn = false;
    bool movingLeft = false;
    public float centerTheta; //Tiene el angulo en el cual el enemigo deberia oscilar
    float originalTheta; //Tiene el angulo de regreso
    public float movementAmplitude = 0.15f; //Amplitud del movimiento zigzageante en porciones de circulo
	// Use this for initialization
	void Start () {
        centerTheta = radialMovement.theta;
        originalTheta = centerTheta;
	}
	
	// Update is called once per frame
	void Update () {
        //Se mueve en un patron zigzageante cuando se le ordena hacerlo
        //Incluye el patron de retorno
        if (!startedGameplay)
        {
            //Para asegurarse que se haya asignado un theta_0
            centerTheta = radialMovement.theta;
            originalTheta = centerTheta;
            startedGameplay = true;
        }
        if (startedMovement && startedGameplay)
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
        else if (startedReturn)
        {
            //Aqui retrocede hasta llegar al inicio
            if (transform.position.z >= 0 && transform.position.z < radialMovement.max_distance)
            {
                radialMovement.moveForward();
            }
            else
            {
                startedReturn = false;
                startedMovement = true;
            }


        }
        if (transform.position.z <= 0)
        {
            //Comienza el patron para que la nave vuelva a su posicion inicial
            startedMovement = false;
            startedReturn = true;
        }
        
        
	}

    void changeDirection()
    {
        //Cambia la direccion del enemigo de acuerdo a la distancia angular
        //recorrida
        float delta = centerTheta - radialMovement.theta;

        if (Mathf.Abs(delta) >=(movementAmplitude*(2*Mathf.PI)))
        {
            movingLeft = !movingLeft; //Deberia cambiar de true a false y viceversa
            //followPlayer(); //Queremos que siga al jugador solo despues de una oscilacion
        }
        

    }
    void followPlayer()
    {
        //Trata de que girar en la misma direccion que el jugador
        if (centerTheta - playerRadialMovement.theta > 0)
        {
            centerTheta += radialMovement.getAngularSpeed();
        }
        else if (centerTheta - playerRadialMovement.theta < 0)
        {
            centerTheta -= radialMovement.getAngularSpeed();
        }
        centerTheta = RadialMovementScript.getTrueAngle(centerTheta);
        
    }

}
