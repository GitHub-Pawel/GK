using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Interactible focus;	// Our current focus: Item, Enemy etc.
    public float health = 100f;
    public int towerCounter = 5;
    Camera cam;			// Reference to our camera

    void Start () {
        cam = Camera.main;
    }
    public void onTowerAttack(float healthDrop)
    {
        health -= healthDrop;
        if (health <= 0)
        {
            #if UNITY_EDITOR
                    //TODO Display EndGameGUI in this place
                    Debug.Log("YOU LOSE");
                    UnityEditor.EditorApplication.isPlaying = false;
            #else
                    Application.Quit ();
            #endif
        }
    }

    
    private void Update()
    {
        if (towerCounter == 0)
        {
            //TODO Display EndGameGUI in this place
            Debug.Log("YOU WIN");
            UnityEditor.EditorApplication.isPlaying = false;
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
        // If our focus has changed
        if (newFocus != focus)
        {
            // Defocus the old one
            if (focus != null)
                //focus.OnDefocused();
                //
            Debug.Log("Focused now set to "+focus.name);
            focus = newFocus;	// Set our new focus
        }
		
        //newFocus.OnFocused(transform);
    }
    void RemoveFocus ()
    {
        if (focus != null)
            //focus.OnDefocused();

        focus = null;
        //motor.StopFollowingTarget();
    }
}
