using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    public int SpinSpeed = 1;

    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y += SpinSpeed;
        transform.rotation = Quaternion.Euler(rotationVector);
        //transform.rotation = Quaternion.Euler(0,0, 1);
    }
}
