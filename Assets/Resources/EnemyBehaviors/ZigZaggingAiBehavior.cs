using UnityEngine;
using System.Collections;

public class ZigZaggingAiBehavior : EnemyAIBehavior {
    public RadialMovementScript radialMovement;
    RadialMovementScript playerRadialMovement;
    bool startedGameplay = false;
    public bool startedMovement = false;
    public bool startedReturn = false;
    bool movingLeft = false;
    public float centerTheta; //Tiene el angulo en el cual el enemigo deberia oscilar
    float oldTheta; //Para 
    float originalTheta; //Tiene el angulo de regreso
    public float movementAmplitude = 0.15f; //Amplitud del movimiento zigzageante en porciones de circulo
	// Use this for initialization
    protected virtual void Init()
    {
        centerTheta = radialMovement.theta;
        originalTheta = centerTheta;
        target = null;
    }
	void Start () {
        Init();
            
	}
	
    protected virtual void UpdateStatus()
    {
        //Se mueve en un patron zigzageante cuando se le ordena hacerlo
        //Incluye el patron de retorno
        if (!startedGameplay)
        {
            //Para asegurarse que se haya asignado un theta_0
            centerTheta = radialMovement.theta;
            originalTheta = centerTheta;
            startedGameplay = true;
        }
        if (transform.position.z <= 0)
        {
            //Comienza el patron para que la nave vuelva a su posicion inicial
            startedReturn = true;
            startedMovement = false;
        }
        if (!startedReturn)
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
            if (startedMovement)
            {
                radialMovement.moveForward(-1f);
            }
        }
        else if (startedReturn)
        {
            //Aqui retrocede hasta llegar al inicio
            if (transform.position.z >= 0 && transform.position.z < radialMovement.max_distance)
            {
                //    followPlayer();
                //    radialMovement.setAngle(centerTheta);
                radialMovement.moveForward();
            }
            else
            {
                startedReturn = false;
            }


        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        UpdateStatus();
	}
    public override void SetTarget(GameObject target)
    {
        base.SetTarget(target);
        if(target)
        {
            playerRadialMovement = target.GetComponent<RadialMovementScript>();
        }
    }
        
    //Se encargan de que el enemigo empieze a moverse de acuerdo a este comportamiento
    public override void StartMovement()
    {
        if (!startedReturn)
        {
            startedMovement = true;
        }
    }
    public override void StopMovement()
    {
        startedMovement = false;
        startedReturn = true;
    }
    void changeDirection()
    {
        //Cambia la direccion del enemigo de acuerdo a la distancia angular
        //recorrida
        float delta = centerTheta - radialMovement.theta;

        if (Mathf.Abs(delta) >=(movementAmplitude*(2*Mathf.PI)))
        {
            movingLeft = !movingLeft; //Deberia cambiar de true a false y viceversa
            if (target != null)
            {
                followPlayer(); //Queremos que siga al jugador solo despues de una oscilacion completa
            }
        }
        

    }
    void followPlayer()
    {
        
        //Trata de que girar en la misma direccion que el jugador, ademas
        //pide que cambie de direccion solo si la oscilacion es en la misma
        //direccion del player
        if (centerTheta - playerRadialMovement.theta > 0 && movingLeft)
        {
            centerTheta -= 2*radialMovement.getAngularSpeed();
            //radialMovement.moveLeft();
        }
        else if (centerTheta - playerRadialMovement.theta < 0 && !movingLeft)
        {
            centerTheta += 2*radialMovement.getAngularSpeed();
            //radialMovement.moveRight();
        }
        centerTheta = RadialMovementScript.getTrueAngle(centerTheta);
        
    }

}
