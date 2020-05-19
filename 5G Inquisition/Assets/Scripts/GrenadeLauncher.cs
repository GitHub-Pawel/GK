using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    // vars
    public Transform spawnPoint;
    public GameObject grenade;

    float throwForce = 20f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        if (Input.GetMouseButtonDown(1))
            Launch();
    }

    private void Launch()
    {
        GameObject grenadeInstance = Instantiate(grenade, spawnPoint.position, spawnPoint.rotation) as GameObject;
        grenadeInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*throwForce, ForceMode.Impulse);
    }


}
