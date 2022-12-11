using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]

public class EnemyScriptableObject : ScriptableObject
{
    public new string name;
    public int maxHealth;
    public int health;
    public int damage;
    public Transform prefab;
}
