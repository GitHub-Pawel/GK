using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    // vars
    public Transform spawnPoint;
    public GameObject grenade;
    public PlayerAnimation playerAnimation;

    float throwForce = 20f;

    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        if (Input.GetMouseButtonDown(1) && !playerAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("Grenade Throw"))
            Launch();
    }

    private void Launch()
    {
        GameObject grenadeInstance = Instantiate(grenade, spawnPoint.position, spawnPoint.rotation) as GameObject;
        grenadeInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*throwForce, ForceMode.Impulse);
    }


}
