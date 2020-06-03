using System;
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
            if (!GameObject.Find("WPN_MK2Grenade(Clone)"))
                Launch();
    }

    public void Launch()
    {
        playerAnimation.animator.SetTrigger("GrenadeThrow");
        playerAnimation.audioSource.PlayOneShot(playerAnimation.grenadeThrowSound);
        GameObject grenadeInstance = Instantiate(grenade, spawnPoint.position, spawnPoint.rotation) as GameObject;
        grenadeInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.forward*throwForce, ForceMode.Impulse);
    }


}
