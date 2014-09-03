using UnityEngine;
using System.Collections;

public class ScorableBehavior : MonoBehaviour {
    //Se encarga de mantener y actualizar el puntaje del jugador
    int score;
    public GUIText scoreText; 
    public void addScore(int scorePerShip)
    {
        //Agrega el puntaje dado por el enemigo al jugador
        score += scorePerShip;
        scoreText.text = score.ToString();
    }
	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
