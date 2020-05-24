using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;
    private GameObject clone;

    public Tower tower;
    public float towerLifeLevel;
    public Player player;

    void Start() {
        if (destroyedVersion)
        {
            if (!gameObject.name.Contains("(Clone)"))
            {
                towerLifeLevel = tower.config.health;
            }
        }
        
    }

    void Punch()
    {
        var rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log("Punching!");
            rb.AddForce(Camera.main.transform.forward * 69, ForceMode.Impulse);
        }
    }

    private void OnMouseDown()
    {
        if (towerLifeLevel > 0)
        {
            HurtTheTower();
        }
        else{
            Punch();
            DestroyDestructible();
            //Debug.Log(String.Format("Number of remaining towers: " + player.towerCounter)); //When tower is destroyed, destroyed version appears with NEW VERSION of this script, which doesn't have player or tower assigned and produces NULL EXCEPTIONS
        }
    }
    
    public void HurtTheTower()
    {
        towerLifeLevel -= 10;
        Debug.Log(String.Format("Tower life level decremented: " + towerLifeLevel));
    }

    public void DestroyDestructible()
    {
        
        if(destroyedVersion)
        {
            if (!gameObject.name.Contains("(Clone)"))
            {
                Debug.Log("Destroying!");
                Debug.Log(gameObject.tag);
                var transformInfo = gameObject.transform;
                clone = Instantiate(destroyedVersion, transformInfo.position, transformInfo.rotation);
                Destroy(gameObject);
                player.towerCounter--;    //TODO make player.towerCounter attribute as private + use getter/setter
            }
            
        }
    }


    
}