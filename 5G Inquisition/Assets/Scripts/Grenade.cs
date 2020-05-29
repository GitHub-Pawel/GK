using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    [SerializeField] float timer = 2f;
    float countdown;
    [SerializeField] float radius = 3f;
    [SerializeField] float force = 50f;

    bool hasExploded = false;

    [SerializeField] GameObject exploParticle;

    [SerializeField] public AudioClip grenadeExplosionSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        countdown = timer;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded)
        {
            print("Explode");
            Explode();
        }
    }

    void Explode()
    {
        GameObject spawnedParticle = Instantiate(exploParticle, transform.position, transform.rotation);
        Destroy(spawnedParticle, 1);

        audioSource.PlayOneShot(grenadeExplosionSound);
        Collider [] collidersToDeatroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToDeatroy)
        {
            Destructible dest = nearbyObject.GetComponent<Destructible>();
            if (dest != null)
            {
                dest.DestroyDestructible();
            }
        }
        
        Collider [] collidersToPunch = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in collidersToPunch)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        
        hasExploded = true;
        Destroy(gameObject);
    }
}
