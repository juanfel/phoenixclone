using UnityEngine;
using System.Collections;

public class RadialMovementScript : MonoBehaviour {

    //Se encarga de dar las funciones de movimiento radial a las distintos
    //tipos de naves
    public float max_distance;
    public float theta;
    public float radius = 4;
    public float speed; //en porciones de circulo por segundo
    float realSpeed; //en angulos por update
    public float linealSpeed; //En unidades por segundo
    float realLinealSpeed; //En unidades por update
    public const float MAX_ANGLE = 2f*Mathf.PI;
    public const float MAX_SPEED = 5f;
    Quaternion angleQuat;
    public Vector3 position;
    // Use this for initialization
    void Start()
    {
        //Obtiene un angulo dado por la posicion inicial de la entidad
        position = transform.position;
        position.z = 0;
        theta = Vector3.Angle(Vector3.right,position); //En grados
        theta = theta * Mathf.Deg2Rad;

        //Con el producto punto se obtiene la direccion relativa del vector posicion
        //con respecto a 0
        float signo_theta = Mathf.Sign(Vector3.Cross(Vector3.right, transform.position).z);
        if (signo_theta < 0)
        {
            theta = 2 * Mathf.PI - theta; //Si da un angulo negativo busca su equivalente positivo
        }
        //Ajusta la entidad al cilindro
        position = new Vector3(radius *1.5f* Mathf.Cos(theta), radius * Mathf.Sin(theta), 
           transform.position.z);
        Mathf.Clamp(transform.position.z, 0, max_distance);
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
        position.z = Mathf.Clamp(position.z, 0, max_distance);
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
        //Si es un angulo negativo o uno mas grande que el maximo da su complemento
        if (angle < 0)
        {
            return Mathf.Abs(MAX_ANGLE + angle);
        }
        else if (angle > MAX_ANGLE)
        {
            return Mathf.Abs(angle - MAX_ANGLE);
        }
        return angle;

    }
    public static float getAcuteAngleBetween(float angle1, float angle2)
    {
        //Saca el angulo mas chico entre angle1 y angle2, para ver mejor como acercarse
        //al player, por ejemplo.
        //Para esto ve si es menor la diferencia directa de 
        float delta = Mathf.Abs(angle1 - angle2);
        return Mathf.Min(MAX_ANGLE - delta, delta);

    }
    public static float getAcuteAngleBetween(Vector3 pos1, Vector3 pos2)
    {
        //Calcula el angulo entre 2 vectores, considerando que se descarta z en ambos
        Vector3 newpos1 = pos1;
        Vector3 newpos2 = pos2;
        newpos1.z = 0;
        newpos2.z = 0;

        float angle = Vector3.AngleBetween(newpos1, newpos2);
        angle *= Mathf.Sign(Vector3.Cross(newpos1, newpos2).z);
        return angle;
    }
    
    public void setAngle(float angle)
    {
        //Impone que el theta sea el valor de angle y cambia la posicion de acuerdo a eso
        theta = angle %MAX_ANGLE;
        if (theta < 0)
        {
            theta = MAX_ANGLE + theta;
        }
        position.x = radius * 1.5f * Mathf.Cos(theta);
        position.y = radius * Mathf.Sin(theta);
    }
}
