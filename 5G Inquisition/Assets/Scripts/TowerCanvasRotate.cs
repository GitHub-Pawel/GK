using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCanvasRotate : MonoBehaviour
{
    public GameObject player;
    private Transform _target;

    private void Start()
    {
        player = GameObject.Find("Player");
        _target = player.transform;
    }

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
