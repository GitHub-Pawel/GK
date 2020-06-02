using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatsDisplayer : MonoBehaviour
{
    private GameObject player;
    private PlayerStats playerStats;
    
    private GameObject rageObject;
    private GameObject armourObject;
    private GameObject healthObject;
    private Text rageValue;
    private Text armourValue;
    private Text healthValue;
    
    void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
        rageObject = GameObject.Find("RageValue");
        armourObject = GameObject.Find("ArmourValue");
        healthObject = GameObject.Find("HealthValue");
        rageValue = rageObject.GetComponent<Text>();
        armourValue = armourObject.GetComponent<Text>();
        healthValue = healthObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthValue.text = playerStats.currentHealth.ToString();
        armourValue.text = playerStats.armor.GetValue().ToString();
        rageValue.text = playerStats.damage.GetValue().ToString();
    }
}
