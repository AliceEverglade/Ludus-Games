using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObjects/Enemy")]

public class EnemySO : ScriptableObject
{
    public new string name;

    public bool isDead;
    public bool isBoss;

    public int actionPoints;
    public int currentActionPoints;

    public float maxHP;
    public float currentHP;
    public float damage;
    public float specialDamage;
    public float critChance;
    public float critDamage;
    public float healing;


    public GameObject prefab;

    public void StartTurn()
    {
        //deal DOT damage
        Debug.Log("enemy turn started");
        currentActionPoints = actionPoints;
    }

    public bool TakeDamage(float damage)
    {
        currentHP -= damage;
        return isDead = currentHP < 0 ? true : false;
    }
    public void Heal(float amount)
    {
        currentHP += amount;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
