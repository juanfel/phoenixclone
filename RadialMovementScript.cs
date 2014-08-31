using UnityEngine;
using System.Collections;

public class RadialMovementScrip : MonoBehaviour {
    //Se encarga de dar las funciones de movimiento radial a las distintos
    //tipos de naves
    public float theta_0;
    public float theta;
    static float radius = 1;
    public float speed; //en angulo
    Vector3 position;

	// Use this for initialization
	void Start () {
        theta_0 = 0;
        position = new Vector3(radius, 0, -radius);
        speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = position;
        moveRight();
	}

    void moveLeft()
    {
        theta -= speed;
    }
    void moveRight()
    {
        theta += speed;
    }
}
