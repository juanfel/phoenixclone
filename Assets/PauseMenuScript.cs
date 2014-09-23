using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

    bool paused;
	// Use this for initialization
	void Start () {
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Pause"))
        {
            PauseUnpause();
        }
	}
    Rect bigRect = new Rect(
            ((int)Screen.width * 0.3f), ((int)Screen.height * 0.2f),
            ((int)Screen.width * 0.4f), ((int)Screen.height * 0.4f));
    void OnGUI()
    {
        if(paused)
        {
            GUI.Window(0, bigRect, showExitButtons, "Pausado");
        }
    }
    void showExitButtons(int windowID)
    {

    }
    void PauseUnpause()
    {
        //Toglea el pause y hace la accion de pausa
        if(paused)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        paused = !paused;
    }
}
