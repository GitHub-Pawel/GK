using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerConfig", menuName = "5G_Inquisition/TowerConfig")]

public class TowerConfig : ScriptableObject
{
    [Range(10, 500)]
    public float health = 100f;
    [Range(0.1f, 10)]
    public float power = 2f;
    [Range(1, 100)]
    public float range = 10f;
    [Range(1, 10)]
    public float attackIntervalSec = 2f;
}
