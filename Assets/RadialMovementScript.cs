using UnityEngine;
using System.Collections;

public class RadialMovementScript : MonoBehaviour {

    //Se encarga de dar las funciones de movimiento radial a las distintos
    //tipos de naves
    public float initial_distance;
    public float theta;
    public float radius = 4;
    public float speed; //en porciones de circulo por segundo
    float realSpeed; //en angulos por update
    public float linealSpeed; //En unidades por segundo
    float realLinealSpeed; //En unidades por update
    public const float MAX_ANGLE = 2f*Mathf.PI;
    public const float MAX_SPEED = 5f;
    Quaternion angleQuat;
    Vector3 position;
    // Use this for initialization
    void Start()
    {
        //Obtiene un angulo dado por la posicion inicial de la entidad
        
        theta = Vector3.Angle(Vector3.right,transform.position); //En grados
        theta = theta * Mathf.Deg2Rad;

        //Con el producto punto se obtiene la direccion relativa del vector posicion
        //con respecto a 0
        float signo_theta = Mathf.Sign(Vector3.Cross(Vector3.right, transform.position).z);
        if (signo_theta < 0)
        {
            theta = 2 * Mathf.PI - theta; //Si da un angulo negativo busca su equivalente positivo
        }
        //Ajusta la entidad al cilindro
        position = new Vector3(radius *1.5f* Mathf.Cos(theta), radius * Mathf.Sin(theta), initial_distance);
        //Convierte las unidades entendibles por los humanos
        //a las apropiadas para el computador
        realSpeed = Time.fixedDeltaTime * (speed*MAX_ANGLE);
        realLinealSpeed = Time.fixedDeltaTime * linealSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = position;
        transform.eulerAngles = new Vector3(0,0,theta*Mathf.Rad2Deg);
    }
   
    void FixedUpdate()
    {
        
   
    }
    //moveLeft y moveRight mueven a la nave en la direccion indicada, como
    //si la nave estuviese en un circulo. Esto implica que si la nave esta dada vuelta 
    //se va a mover en la direccion contraria
    public void moveLeft()
    {
        moveSideways(1f); 
    }
    public void moveRight()
    {
        moveSideways(-1f);
    }
    public void moveSideways(float axis)
    {
        theta = (theta + Mathf.Sign(axis)*realSpeed) % MAX_ANGLE;
        if (theta < 0)
        {
            theta = MAX_ANGLE + theta;
        }
        position.x = radius* 1.5f * Mathf.Cos(theta);
        position.y = radius * Mathf.Sin(theta);
    }
    public void moveForward(float axis)
    {
        //Acerca o aleja al actor de la camara
        position.z = (position.z + Mathf.Sign(axis) * realLinealSpeed);
        position.z = Mathf.Clamp(position.z, 0, initial_distance);
    }
    public void moveForward()
    {
        //Alias para que actor avanze hacia la camara
        moveForward(1f);
    }
    public float getAngularSpeed()
    {
        //devuelve la velocidad angular real
        return realSpeed;
    }
    public float getLinearSpeed()
    {
        //Devuelve la velocidad lineal real
        return realLinealSpeed;
    }
    public static float getTrueAngle(float angle)
    {
        //Si es un angulo negativo da su complemento
        if (angle < 0 || angle > MAX_ANGLE)
        {
            return Mathf.Abs(MAX_ANGLE - angle);
        }
        return angle;

    }
}
