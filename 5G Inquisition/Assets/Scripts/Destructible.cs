using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    
    public GameObject destroyedVersion;
    private GameObject clone;

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
        
        Punch();
        
        if(destroyedVersion)
        {
            Debug.Log("Destroying!");
            var transformInfo = gameObject.transform;
            clone = Instantiate(destroyedVersion, transformInfo.position, transformInfo.rotation);
            Destroy(gameObject);
            Punch();
        }
        
    }


    
}