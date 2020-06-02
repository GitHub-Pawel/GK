﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class Player : MonoBehaviour
{
    public Interactible focus;	// Our current focus: Item, Enemy etc.
    public int towerCounter = 5;
    private bool healing;
    Camera cam;			// Reference to our camera
    public SceneSwitcher sceneSwitcher;
    private PlayerStats playerStats;

    

    [SerializeField] public AudioClip towerAttackSound;
    public AudioSource audioSource;
    
    
    void Start () {
        playerStats = GetComponent<PlayerStats>();
        cam = Camera.main;
        //health = startingHealth;
        audioSource = GetComponent<AudioSource>();
    }
    
    
    public void onTowerAttack(float healthDrop)
    {
        
        //health -= healthDrop;
        audioSource.PlayOneShot(towerAttackSound);
        
    }
    
   

    private void Update()
    {
        if (towerCounter == 0)
        {
            sceneSwitcher.YouWin();
        }
        
        // If we press right mouse
        if (Input.GetMouseButtonDown(0))
        {
            // We create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.collider.name);
                Interactible interactable = hit.collider.GetComponent<Interactible>();
                if (interactable != null)
                {
                    Debug.Log("Focused on "+interactable.name);
                    SetFocus(interactable);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q pressed");
            if (focus != null)
            {
                Debug.Log("Removing focus on "+focus.name);
                RemoveFocus();
            }
        }
    }
    void SetFocus (Interactible newFocus)
    {
        Debug.Log("SetFocus invoked. Equipped something");
        if (newFocus != focus)
        {
            if (focus != null)
            { 
                focus.OnDefocused();
            }
            focus = newFocus; // Set our new focus
            Debug.Log("Focused now set to " + focus.name);
        }
        newFocus.OnFocused(transform);
        //isFoilHatEquipped();
    }
    
    void RemoveFocus ()
    {
        
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        healing = false;

        
    }
}
