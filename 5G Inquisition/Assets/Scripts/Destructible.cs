using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;
    private GameObject clone;
    public int towerLifeLevel = 100;

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
        towerLifeLevel -= 20;
        if (towerLifeLevel <= 0) {
            Punch();
            DestroyDestructible();
        }
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
            }
            
        }
    }


    
}