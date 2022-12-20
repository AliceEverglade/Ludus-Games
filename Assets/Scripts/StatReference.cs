using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StatReference
{
    public bool UseConstant;
    public string constantName;
    public int constantMaxHealth;
    public int constantHealth;
    public int constantDamage;
    public Transform constantPrefab;
    public EnemySO enemyStats;
}
