using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private PlayerStats playerStats;
    public Slider slider;

    void Start() {
        playerStats = GetComponent<PlayerStats>();
    }
    void Update()
    {
        slider.value = playerStats.currentHealth;        
    }
}
