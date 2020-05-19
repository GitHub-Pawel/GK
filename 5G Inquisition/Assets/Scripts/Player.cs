using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public int towerCounter = 5;
    
    public void onTowerAttack(float healthDrop)
    {
        health -= healthDrop;
        if (health <= 0)
        {
            #if UNITY_EDITOR
                    //TODO Display EndGameGUI in this place
                    Debug.Log("YOU LOSE");
                    UnityEditor.EditorApplication.isPlaying = false;
            #else
                    Application.Quit ();
            #endif
        }
    }

    private void Update()
    {
        if (towerCounter == 0)
        {
            //TODO Display EndGameGUI in this place
            Debug.Log("YOU WIN");
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
