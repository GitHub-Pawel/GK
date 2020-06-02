using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public float range = 10f;
    public int healingPower = 2;
    public int healingFrequency = 1;
    
    private GameObject player;
    private PlayerStats playerStats;
    private bool healing;
    void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
        HealCorutine();
    }

    private IEnumerator HealCorutine()
    {
        while (healing)
        {
            Debug.Log("HEAL EXECUTED");
            playerStats.Heal(healingPower);
            yield return new WaitForSeconds(healingFrequency);
        }
       
    }
    
    void checkDistance()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < range)
        {
            Debug.Log("IN RANGE OF HEALING");
            if(!healing)
            {
                healing = true;
                StartCoroutine(HealCorutine());
            }
        }
        else
        {
            healing = false;
        }
    }

    private void Update()
    {
        checkDistance();
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float theta = 0;
        float x = range * Mathf.Cos(theta);
        float y = range * Mathf.Sin(theta);
        Vector3 pos = transform.position + new Vector3(x, 0, y);
        Vector3 newPos = pos;
        Vector3 lastPos = pos;
        for (theta = 0.1f; theta < Mathf.PI * 2; theta += 0.1f)
        {
            x = range * Mathf.Cos(theta);
            y = range * Mathf.Sin(theta);
            newPos = transform.position + new Vector3(x, 0, y);
            Gizmos.DrawLine(pos, newPos);
            pos = newPos;
        }
    }
}
