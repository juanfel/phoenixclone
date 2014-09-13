using UnityEngine;
using System.Collections;

public class HighScoreManagerScript : MonoBehaviour {
    GameObject GuiManager;
    GUIText scoretext;
    GUIText highscoretext;
    bool isHighscore = false;
	// Use this for initialization
	void Start () {
        GuiManager = GameObject.FindGameObjectWithTag("GuiManager");
        scoretext = GuiManager.GetComponent<PersistenScoreScript>().getScoreText();
        if(int.Parse(scoretext.text) > int.Parse(highscoretext.text))
        {
            isHighscore = true;
            highscoretext.text = scoretext.text;
            scoretext.text = "0";
        }
        else
        {
            Application.LoadLevel("mainmenu");
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
    void onGui()
    {

    }
}
