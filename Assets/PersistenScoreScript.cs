using UnityEngine;
using System.Collections;

public class PersistenScoreScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    GUIText getScoreText()
    {
        //Obtiene el texto con el score del hijo que lo tiene
        return transform.Find("Score Text").GetComponent<GUIText>();
    }
    GUIText getLivesText()
    {
        //Obtiene el texto con las vidas
        return transform.Find("Lives Text").GetComponent<GUIText>();
    }
}
