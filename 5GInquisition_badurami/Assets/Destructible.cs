using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;
    

    void OnMouseDown()
    {
        
        // ReSharper disable once Unity.InefficientPropertyAccess
        Destroy(gameObject);
        var transformInfo = gameObject.transform;
        Instantiate(destroyedVersion, transformInfo.position, transformInfo.rotation);
        Debug.Log(transformInfo.position);
        Debug.Log("Destructible Script Used");
        //var rb = destroyedVersion.GetComponent<Rigidbody>();
        //rb.AddForce(Camera.main.transform.forward*100, ForceMode.Impulse);
    }
    
  
   
}
