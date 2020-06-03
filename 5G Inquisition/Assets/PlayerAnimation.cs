using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    [SerializeField] public AudioClip baseballSwooshSound;
    [SerializeField] public AudioClip grenadeThrowSound;
    public AudioSource audioSource;

    void Start() {
        animator = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        playAttackAnimation();
        //playGrenadeAnimation();
        playWalkAnimation();
    }

    public void playAttackAnimation() {
        if (Input.GetMouseButtonDown(0) && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Baseball Hit")) {
            animator.SetTrigger("BaseballHit");
            audioSource.PlayOneShot(baseballSwooshSound);
        }
    }
    
    /*
    public void playGrenadeAnimation() {
        if (Input.GetMouseButtonDown(1) && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("Grenade Throw")) {
            animator.SetTrigger("GrenadeThrow");
            audioSource.PlayOneShot(grenadeThrowSound);
        }
    }
    */

    public void playWalkAnimation() {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")) {
            animator.SetBool("Walk", true);
        } else {
            animator.SetBool("Walk", false);
        }
    }
}
