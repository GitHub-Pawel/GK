using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class PostProcessingController : MonoBehaviour
{
    private PostProcessVolume m_PostProcessVolume;
    public GameObject gameManager;
    private EquipmentManager equipmentManager;
    private PlayerStats playerStats;
    void Start()
    {
        m_PostProcessVolume = GetComponent<PostProcessVolume>();
        equipmentManager = gameManager.GetComponent<EquipmentManager>();
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdatePostProcessing () {
        Debug.Log("Updating PP");
        if (!isFoilHatEquipped())
        {
            LensDistortion lensDistortion;
            Vignette vignette;
            Bloom bloom;
            m_PostProcessVolume = GetComponent<PostProcessVolume>();
            if (m_PostProcessVolume.profile.TryGetSettings(out lensDistortion))
            {
                lensDistortion.intensity.value = -((100f - playerStats.currentHealth)/1.4f);
                Debug.Log("Inceasing distortion to " + lensDistortion.intensity.value);
            }
            if (m_PostProcessVolume.profile.TryGetSettings(out vignette))
            {
                vignette.color.value = Color.red;
                if (vignette.intensity.value < .8f)
                {
                    vignette.intensity.value = playerStats.GetHealthLost()/100;
                    //Debug.Log("Inceasing vignette to " + vignette.intensity.value);
                }
            
            }
            if (m_PostProcessVolume.profile.TryGetSettings(out bloom))
            {
                bloom.intensity.value = 0;
            }
        }
    }
    
    private bool isFoilHatEquipped()
    {
        if (equipmentManager.GetEquippedItemName(2) == "Heavenly Hat of Foil")
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
        
            Debug.Log("[PPC]: FoilHat Equipped");

            // healing = true;
            // StartCoroutine(Heal());
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private void unequipFoilHat()
    {
        if (equipmentManager.GetEquippedItemName(2) == "Heavenly Hat of Foil")
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

}
