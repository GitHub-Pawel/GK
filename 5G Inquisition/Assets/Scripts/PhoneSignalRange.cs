using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneSignalRange : MonoBehaviour
{
    public TowerConfig config;
    public bool destroyed;
    public Player player;
    public Image image;
    public Sprite signal_0;
    public Sprite signal_1;
    public Sprite signal_2;
    public Sprite signal_3;
    public Sprite signal_4;
    public Sprite signal_5;

    private void Start()
    {
        destroyed = false;
    }

    void Update()
    {
        if (!destroyed)
        {
            updateRangeIcon();
        }
        else
        {
            image.overrideSprite = null;
        }
    }

    public void updateRangeIcon()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < config.range)
        {
            image.overrideSprite = signal_5;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) < config.range*1.5)
        {
            image.overrideSprite = signal_4;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) < config.range*2)
        {
            image.overrideSprite = signal_3;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) < config.range*2.5)
        {
            image.overrideSprite = signal_2;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) < config.range*3.5)
        {
            image.overrideSprite = signal_1;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) < config.range*5)
        {
            image.overrideSprite = null;
        }
    }
}
