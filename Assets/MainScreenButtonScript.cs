using UnityEngine;
using System.Collections;

public class MainScreenButtonScript : MonoBehaviour {
    bool isCredits;
	// Use this for initialization
	void Start () {
        isCredits = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    Rect bigRect = new Rect(
            ((int)Screen.width * 0.4f), ((int)Screen.height * 0.2f),
            ((int)Screen.width * 0.3f), ((int)Screen.height * 0.4f));
    Rect returnRect = new Rect(
            ((int)Screen.width * 0.1f), ((int)Screen.height * 0.35f),
            ((int)Screen.width * 0.1f), ((int)Screen.height * 0.05f));
    Rect textRect = new Rect(
            ((int)Screen.width * 0.03f), ((int)Screen.height * 0.1f),
            ((int)Screen.width * 1f), ((int)Screen.height * 0.2f));
    Rect subtextRect = new Rect(
            ((int)Screen.width * 0.05f), ((int)Screen.height * 0.17f),
            ((int)Screen.width * 0.2f), ((int)Screen.height * 0.2f));
    void OnGUI()
    {
        GUI.skin.label.wordWrap = true;
        if(!isCredits)
        {
            GUI.Box(new Rect(
            ((int)Screen.width * 0.4f), ((int)Screen.height * 0.2f),
            ((int)Screen.width * 0.2f), ((int)Screen.height * 0.4f)), "NeoPhoenix");
            if (GUI.Button(new Rect(
                ((int)Screen.width * 0.45f), ((int)Screen.height * 0.4f),
                ((int)Screen.width * 0.1f), ((int)Screen.height * 0.1f)), "Play"))
            {
                Application.LoadLevel("gameplay");
            }
            if (GUI.Button(new Rect(
                ((int)Screen.width * 0.45f), ((int)Screen.height * 0.5f),
                ((int)Screen.width * 0.1f), ((int)Screen.height * 0.1f)), "Credits"))
            {
                isCredits = true;
            }
        }
        else
        {
            GUI.Window(0, bigRect, showCredits, "Creditos");
        }
        
    }
    void showCredits(int windowId)
    {

        if(GUI.Button(returnRect,"Main Menu"))
        {
            isCredits = false;
        }
        GUI.Label(textRect, "Inspired by phoenix\n Autor: Juan Felipe Avalo\n Content:");
        string art1 = "Bert-o-Naught (http://opengameart.org/content/space-shooter-top-down-2d-pixel-art)\n";
        string art2 = " Skorpio (original parts) and Wubitog (http://opengameart.org/content/spaceships-from-parts-part2artcom)";
        GUILayout.BeginArea(subtextRect);
        GUILayout.Label(art1 + art2);
        GUILayout.EndArea();
    }
}
