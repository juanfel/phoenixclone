using UnityEngine;
using System.Collections;

public class MainScreenButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        GUI.Box(new Rect(
            ((int)Screen.width*0.4f),((int)Screen.height*0.2f), 
            ((int)Screen.width*0.2f), ((int)Screen.height*0.4f)), "NeoPhoenix");
        if (GUI.Button(new Rect(
            ((int)Screen.width*0.45f),((int)Screen.height*0.4f), 
            ((int)Screen.width*0.1f), ((int)Screen.height*0.1f)), "Play"))
        {
            Application.LoadLevel("gameplay");
        }
        if (GUI.Button(new Rect(
            ((int)Screen.width*0.45f),((int)Screen.height*0.5f), 
            ((int)Screen.width*0.1f), ((int)Screen.height*0.1f)), "Credits")) 
        {
            Debug.Log("Credits?");
        }
    }
}
