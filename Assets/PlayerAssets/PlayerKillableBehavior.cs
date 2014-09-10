using UnityEngine;
using System.Collections;

public class PlayerKillableBehavior : KillableBehavior {

	//Añade todo lo de KillableBehavior y ademas agrega la actualizacion de la pantalla
    public GUIText livesText;
    void Start()
    {
        livesText = GameObject.FindGameObjectWithTag("GuiManager").GetComponent<PersistenScoreScript>().getLivesText();
        livesText.text = hitpoints.ToString();
    }
    public override void RemoveHitpoint(int damage, GameObject attacker)
    {
        base.RemoveHitpoint(damage, attacker);
        livesText.text = hitpoints.ToString();
    }
}
