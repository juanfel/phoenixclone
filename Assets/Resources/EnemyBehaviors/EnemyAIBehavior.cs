﻿using UnityEngine;
using System.Collections;

public class EnemyAIBehavior : MonoBehaviour {
    //Define una clase base para todos los comportamientos de la AI
    public GameObject target;
    public WaveManagerScript waveManager;
    public virtual void StartMovement()
    {

    }
    public virtual void StopMovement()
    {

    }
    public virtual void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
