using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;

    void OnMouseDown()
    {
        if (destroyedVersion)
        {
            Debug.Log("Destructible Script Used");
            Destroy(gameObject);
            var transformInfo = gameObject.transform;
            Instantiate(destroyedVersion, transformInfo.position, transformInfo.rotation);

        }
        else
        {
            Debug.Log("Destructible Script Used On Pieces");
            var rb = GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward*100, ForceMode.Impulse);
        }
    }
    
  
   
}
