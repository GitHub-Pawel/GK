using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class Player : MonoBehaviour
{
    public Interactible focus;	// Our current focus: Item, Enemy etc.
    public float startingHealth = 100f;
    public float health;
    public int towerCounter = 5;
    private bool healing;
    Camera cam;			// Reference to our camera
    public SceneSwitcher sceneSwitcher;

    private PostProcessVolume m_PostProcessVolume;
    
    
    void Start () {
        cam = Camera.main;
        health = startingHealth;
    }

    private float healthLost()
    {
        return startingHealth - health;
    }

    private void ControlPostProcessingWeight () {
        if (!isFoilHatEquipped())
        {
            LensDistortion lensDistortion;
            Vignette vignette;
            m_PostProcessVolume = GetComponent<PostProcessVolume>();
            if (m_PostProcessVolume.profile.TryGetSettings(out lensDistortion))
            {
                lensDistortion.intensity.value = -((100f - health)/1.4f);
                Debug.Log("Inceasing distortion to " + lensDistortion.intensity.value);
            }
            if (m_PostProcessVolume.profile.TryGetSettings(out vignette))
            {
                vignette.color.value = Color.red;
                if (vignette.intensity.value < .8f)
                {
                    vignette.intensity.value = healthLost()/100;
                    //Debug.Log("Inceasing vignette to " + vignette.intensity.value);
                }
            
            }
        }
    }
    public void onTowerAttack(float healthDrop)
    {
        health -= healthDrop;
        ControlPostProcessingWeight();
        
        if (health <= 0)
        {
            sceneSwitcher.GameOver();
        }
    }
    
    private IEnumerator Heal()
    {
        while(healing)
        {
            if (health <= startingHealth-5)
            {
                health += 5f;
                Debug.Log("Healed to "+health);
                
            }
            else
            {
                health = startingHealth;
                Debug.Log("Healed to "+health);
            }
            
            yield return new WaitForSeconds(2f);

        }
    }

    private bool isFoilHatEquipped()
    {
        if (focus != null && focus.name == "FoilHat")
        {
            LensDistortion lensDistortion;
            Vignette vignette;
            Bloom bloom;
            m_PostProcessVolume = GetComponent<PostProcessVolume>();
            if (m_PostProcessVolume.profile.TryGetSettings(out lensDistortion))
            {
                lensDistortion.intensity.value = 0f;
            }
            if (m_PostProcessVolume.profile.TryGetSettings(out vignette))
            {
                vignette.intensity.value = .5f;
                vignette.color.value = Color.cyan;
            }
            if (m_PostProcessVolume.profile.TryGetSettings(out bloom))
            {
                bloom.intensity.value = 20;
            }

            healing = true;
            StartCoroutine(Heal());
            return true;
        }
        else
        {
            return false;
        }
    }

    private void unequipFoilHat()
    {
        if (focus != null && focus.name == "FoilHat")
        {
            LensDistortion lensDistortion;
            Vignette vignette;
            Bloom bloom;
            m_PostProcessVolume = GetComponent<PostProcessVolume>();
            if (m_PostProcessVolume.profile.TryGetSettings(out lensDistortion))
            {
                lensDistortion.intensity.value = 0f;
            }
            if (m_PostProcessVolume.profile.TryGetSettings(out vignette))
            {
                vignette.intensity.value = 0f;
                vignette.color.value = Color.clear;
            }
            if (m_PostProcessVolume.profile.TryGetSettings(out bloom))
            {
                bloom.intensity.value = 0;
            }  
        }
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
        isFoilHatEquipped();
    }
    
    void RemoveFocus ()
    {
        //if (focus != null)
        unequipFoilHat();
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        healing = false;
        ControlPostProcessingWeight();

        
    }
}
