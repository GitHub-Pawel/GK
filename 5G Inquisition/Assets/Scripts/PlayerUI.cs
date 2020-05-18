using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private Player player;
    public Slider slider;

    void Start() {
        player = GetComponent<Player>();
    }
    void Update()
    {
        slider.value = player.health;        
    }
}
