using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private bool attacking = false;
    private Player player;
    public TowerConfig config;
    private PlayerStats playerStats;
    
    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        playerStats = player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        checkDistance();
    }

    private IEnumerator Attack()
    {
        while(attacking)
        {
            player.onTowerAttack(config.power);
            playerStats.TakeDamage((int)config.power);
            yield return new WaitForSeconds(config.attackIntervalSec);
        }
    }

    void checkDistance()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < config.range)
        {
            if(!attacking)
            {
                attacking = true;
                StartCoroutine(Attack());
            } 
        }
        else
        {
            attacking = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float theta = 0;
        float x = config.range * Mathf.Cos(theta);
        float y = config.range * Mathf.Sin(theta);
        Vector3 pos = transform.position + new Vector3(x, 0, y);
        Vector3 newPos = pos;
        Vector3 lastPos = pos;
        for (theta = 0.1f; theta < Mathf.PI * 2; theta += 0.1f)
        {
            x = config.range * Mathf.Cos(theta);
            y = config.range * Mathf.Sin(theta);
            newPos = transform.position + new Vector3(x, 0, y);
            Gizmos.DrawLine(pos, newPos);
            pos = newPos;
        }
    }
}
