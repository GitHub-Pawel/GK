using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    private Destructible destructible;
    public Slider slider;

    private void Start()
    {
        destructible = GetComponent<Destructible>();
    }

    void Update()
    {
        slider.value = destructible.towerLifeLevel;
    }
}
