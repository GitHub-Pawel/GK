using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    public float SpinSpeedY = 1;
    public float SpinSpeedX = 0;
    public float SpinSpeedZ = 0;

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
        rotationVector.y += SpinSpeedY;
        rotationVector.x += SpinSpeedX;
        rotationVector.z += SpinSpeedZ;
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
