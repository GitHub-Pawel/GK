using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piecesDespawner : MonoBehaviour
{
    
    public float delay = 10f;
    private float countdown;
    public float fadeSpeed = 1f;
    private MeshRenderer renderer;

    void Start()
    {
        countdown = delay;
        renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            
            fadeOut();

        }
    }

    

    private  void fadeOut()
    {
        Material standardShaderMaterial = renderer.material;
        standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        standardShaderMaterial.SetInt("_ZWrite", 0);
        standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
        standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
        standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        standardShaderMaterial.renderQueue = 3000;
        Color objectColor = standardShaderMaterial.color;
        
        float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
        objectColor= new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        renderer.material.color = objectColor;
        if (objectColor.a < 0)
        {
            Debug.Log("[piecesDespawner]: FadeOut and Despawn");
            Destroy(gameObject);
        }

        
    }
}
