using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start() {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update() {
        playAttackAnimation();
        playGrenadeAnimation();
        playWalkAnimation();
    }

    public void playAttackAnimation() {
        if (Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("BaseballHit");
        }
    }
    
    public void playGrenadeAnimation() {
        if (Input.GetMouseButtonDown(1)) {
            animator.SetTrigger("GrenadeThrow");
        }
    }

    public void playWalkAnimation() {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")) {
            animator.SetBool("Walk", true);
        } else {
            animator.SetBool("Walk", false);
        }
    }
}
