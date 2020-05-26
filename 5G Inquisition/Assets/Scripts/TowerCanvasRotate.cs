using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCanvasRotate : MonoBehaviour
{
    public Transform _target;

    void Update()
    {
        lookAtTarget(_target);
    }

    public void lookAtTarget(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}
