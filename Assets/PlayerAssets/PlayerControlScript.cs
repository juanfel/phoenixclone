using UnityEngine;
using System.Collections;

public class PlayerControlScript : MonoBehaviour {
    //Se encarga de ver los inputs del jugador
    public RadialMovementScript movementScript;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") != 0)
        {
            movementScript.moveSideways(Input.GetAxis("Horizontal"));
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            movementScript.moveForward(Input.GetAxis("Vertical"));
        }
	}
}
