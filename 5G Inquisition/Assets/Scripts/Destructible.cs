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
    public PlayerAnimation playerAnimation;
    public PhoneSignalRange phoneSignalRange;

    [SerializeField] private AudioClip towerBaseballHitSound;
    [SerializeField] public AudioClip towerCollapseSound;
    public AudioSource audioSource;

    void Start() {
        if (destroyedVersion)
        {
            if (!gameObject.name.Contains("(Clone)"))
            {
                towerLifeLevel = tower.config.health;
            }
        }
        audioSource = GetComponent<AudioSource>();
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
        else
        {
            phoneSignalRange.destroyed = true;
            phoneSignalRange.image.overrideSprite = null;
            Punch();
            DestroyDestructible();
            //Debug.Log(String.Format("Number of remaining towers: " + player.towerCounter)); //When tower is destroyed, destroyed version appears with NEW VERSION of this script, which doesn't have player or tower assigned and produces NULL EXCEPTIONS
        }
    }
    
    public void HurtTheTower()
    {
        if (authToHit())
        {
            towerLifeLevel -= 15;
            audioSource.PlayOneShot(towerBaseballHitSound);
            Debug.Log(String.Format("Tower life level decremented: " + towerLifeLevel));
        }
    }

    private bool authToHit()
    {
        if (Vector3.Distance(player.transform.position, tower.transform.position) < 10f)
            if (!playerAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("Baseball Hit"))
                return true;
        return false;
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
                audioSource.PlayOneShot(towerCollapseSound); // nie dziala bo obiekt jest usuwany
                Destroy(gameObject);
                player.towerCounter--;    //TODO make player.towerCounter attribute as private + use getter/setter
            }
            
        }
    }


    
}