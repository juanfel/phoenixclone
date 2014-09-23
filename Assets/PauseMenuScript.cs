using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

    public static bool paused = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Pause"))
        {
            PauseUnpause();
        }
	}
    Rect bigRect = new Rect(
            ((int)Screen.width * 0.4f), ((int)Screen.height * 0.2f),
            ((int)Screen.width * 0.3f), ((int)Screen.height * 0.3f));
    Rect returnRect = new Rect(
            ((int)Screen.width * 0.05f), ((int)Screen.height * 0.1f),
            ((int)Screen.width * 0.2f), ((int)Screen.height * 0.1f));
    Rect mainmenuRect = new Rect(
            ((int)Screen.width * 0.05f), ((int)Screen.height * 0.2f),
            ((int)Screen.width * 0.2f), ((int)Screen.height * 0.1f));
    void OnGUI()
    {
        if(paused)
        {
            GUI.Window(0, bigRect, showExitButtons, "Pausaded");
        }
    }
    void showExitButtons(int windowID)
    {
        if(GUI.Button(returnRect,"Return(esc)"))
        {
            PauseUnpause();
        }
        if(GUI.Button(mainmenuRect,"Exit"))
        {
            PauseUnpause();
            Application.LoadLevel("mainmenu");
        }
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
