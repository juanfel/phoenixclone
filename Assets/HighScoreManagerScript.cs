using UnityEngine;
using System.Collections;

public class HighScoreManagerScript : MonoBehaviour {
    GameObject GuiManager;
    GUIText scoretext;
    GUIText highscoretext;
    GUIText highscoreplayer;
    bool isHighscore = false;
    bool isConfirmed = false;
	// Use this for initialization
	void Start () {
        GuiManager = GameObject.FindGameObjectWithTag("GuiManager");
        scoretext = GuiManager.GetComponent<PersistenScoreScript>().getScoreText();
        highscoretext = GuiManager.GetComponent<PersistenScoreScript>().getHighscoreText();
        highscoreplayer = GuiManager.GetComponent<PersistenScoreScript>().getHighscorePlayer();
        if (int.Parse(scoretext.text) >= int.Parse(highscoretext.text))
        {
            isHighscore = true;
        }
        else
        {
            Application.LoadLevel("mainmenu");
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
    Rect bigRect = new Rect(
            ((int)Screen.width * 0.3f), ((int)Screen.height * 0.2f),
            ((int)Screen.width * 0.4f), ((int)Screen.height * 0.4f));
    Rect siRect = new Rect(
            ((int)Screen.width * 0.1f), ((int)Screen.height * 0.2f),
            ((int)Screen.width * 0.1f), ((int)Screen.height * 0.1f));
    Rect noRect = new Rect(
            ((int)Screen.width * 0.2f), ((int)Screen.height * 0.2f),
            ((int)Screen.width * 0.1f), ((int)Screen.height * 0.1f));
    Rect textRect = new Rect(
            ((int)Screen.width * 0.1f), ((int)Screen.height * 0.2f),
            ((int)Screen.width * 0.1f), ((int)Screen.height * 0.1f));
    void showOptions(int windowID)
    {
        if(GUI.Button(siRect, "Si"))
        {
            isConfirmed = true;
        }
        if(GUI.Button(noRect, "No"))
        {
            scoretext.text = "0";
            Application.LoadLevel("mainmenu");
        }
    }
    string playername = string.Empty;
    void enterText(int windowID)
    {
        playername = GUI.TextField(textRect,playername, 4);
        if(GUI.Button(noRect, "Confirmar"))
        {
            highscoreplayer.text = playername;
            highscoretext.text = scoretext.text;
            scoretext.text = "0";
             Application.LoadLevel("mainmenu");
        }
    }

    void OnGUI()
    {
        if (!isConfirmed && isHighscore)
            GUI.Window(0, bigRect, showOptions, "Desea ingresar highscore?");
        else if (isConfirmed)
        {
            GUI.Window(1, bigRect, enterText, "Ingrese el nombre (Max 4 caracteres)");
        }

    }
}
