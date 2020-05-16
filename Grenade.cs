using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public GameObject explosionEffect;
    private float countdown;
    private bool hasExploded;
    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            
        }
    }

    private void Explode()
    {
        hasExploded = true;
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
