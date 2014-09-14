using UnityEngine;
using System.Collections;

public class PersistenScoreScript : MonoBehaviour {
    static bool created = false;
	// Use this for initialization
	void Start () {
	}
	
	void Awake()
    {
        //Hace que el gameobject sea singleton
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        } 
    }
    public GUIText getScoreText()
    {
        //Obtiene el texto con el score del hijo que lo tiene
        return transform.Find("Score Text").GetComponent<GUIText>();
    }
    public GUIText getLivesText()
    {
        //Obtiene el texto con las vidas
        return transform.Find("Lives Text").GetComponent<GUIText>();
    }
    public GUIText getHighscoreText()
    {
        return transform.Find("Highscore Text").GetComponent<GUIText>();
    }
    public GUIText getHighscorePlayer()
    {
        return transform.Find("Highscore player").GetComponent<GUIText>();
    }


}
