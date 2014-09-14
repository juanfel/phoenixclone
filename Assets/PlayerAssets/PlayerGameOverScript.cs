using UnityEngine;
using System.Collections;

public class PlayerGameOverScript : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //Todo esto se encarga de mostrar la pantalla de gameOver cuando el jugador muere
    bool gameOver = false;
    public void StartGameOver()
    {
        gameOver = true;
    }
    public void ShowGameOver(int windowId)
    {
        Invoke("GoToHighscoreScreen", 3f);

    }
    public void GoToHighscoreScreen()
    {
        gameOver = false;
        Application.LoadLevel("gameover");
    }
    Rect bigRect = new Rect(
            ((int)Screen.width * 0.3f), ((int)Screen.height * 0.2f),
            ((int)Screen.width * 0.2f), ((int)Screen.height * 0.2f));
    void OnGUI()
    {
        if (gameOver)
        {
            GUI.Window(0, bigRect, ShowGameOver, "Game Over");
        }
    }
}
