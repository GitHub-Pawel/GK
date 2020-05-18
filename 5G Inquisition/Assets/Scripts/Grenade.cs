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

    // Start is called before the first frame update
    void Start()
    {
        countdown = timer;
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
