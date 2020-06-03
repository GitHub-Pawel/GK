using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatsDisplayer : MonoBehaviour
{
    private GameObject player;
    private PlayerStats playerStats;
    private Player playerScript;
    private GameObject rageObject;
    private GameObject armourObject;
    private GameObject healthObject;
    private GameObject towersObject;
    private Text rageValue;
    private Text armourValue;
    private Text healthValue;
    private Text towersValue;
    
    void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
        playerScript = player.GetComponent<Player>();
        rageObject = GameObject.Find("RageValue");
        armourObject = GameObject.Find("ArmourValue");
        healthObject = GameObject.Find("HealthValue");
        towersObject = GameObject.Find("TowersValue");
        rageValue = rageObject.GetComponent<Text>();
        armourValue = armourObject.GetComponent<Text>();
        healthValue = healthObject.GetComponent<Text>();
        towersValue = towersObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthValue.text = playerStats.currentHealth.ToString();
        armourValue.text = playerStats.armor.GetValue().ToString();
        rageValue.text = playerStats.damage.GetValue().ToString();
        towersValue.text = playerScript.towerCounter.ToString();
    }
}
