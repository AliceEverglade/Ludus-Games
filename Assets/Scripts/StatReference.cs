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
    public EnemyScriptableObject enemyStats;

    public string Name
    {
        get { return UseConstant ? constantName : enemyStats.name; }
    }
    public int MaxHealth
    {
        get {return UseConstant ? constantMaxHealth : enemyStats.maxHealth;}
    }
    public int Health
    {
        get { return UseConstant ? constantHealth : enemyStats.health; }
    }
    public int Damage
    {
        get { return UseConstant ? constantDamage : enemyStats.damage; }
    }
    public Transform Prefab
    {
        get { return UseConstant ? constantPrefab : enemyStats.prefab; }
    }
}
