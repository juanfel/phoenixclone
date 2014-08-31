using UnityEngine;
using System.Collections;

public class RadialMovementScript : MonoBehaviour {

    //Se encarga de dar las funciones de movimiento radial a las distintos
    //tipos de naves
    public float initial_distance;
    public float theta;
    public float radius = 4;
    public float speed; //en angulos por segundo
    float realSpeed; //en angulos por update
    public float linealSpeed; //En unidades por segundo
    float realLinealSpeed; //En unidades por update
    const float MAX_ANGLE = 2f*Mathf.PI;
    const float MAX_SPEED = 5f;
    Quaternion angleQuat;
    Vector3 position;
    // Use this for initialization
    void Start()
    {
        //Ajusta el sprite inicial al cilindro donde debe moverse
        position = radius*transform.position.normalized;
        position.z = initial_distance;
        theta = Vector3.Angle(Vector3.right,position); //En grados
        theta = theta * Mathf.Deg2Rad;
        //Con el producto punto se obtiene la direccion relativa del vector posicion
        //con respecto a 0
        theta *= Mathf.Sign(Vector3.Cross(Vector3.right, position).z);
        realSpeed = Time.fixedDeltaTime * speed;
        realLinealSpeed = Time.fixedDeltaTime * linealSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = position;
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
}
