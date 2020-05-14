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
    }

    public void playAttackAnimation() {
        if (Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("triggerAttack01");
        }
    }
    
    public void playGrenadeAnimation() {
        if (Input.GetMouseButtonDown(1)) {
            animator.SetTrigger("triggerAttack02");
        }
    }
}
