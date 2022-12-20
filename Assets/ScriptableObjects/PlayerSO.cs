using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/Player")]

public class PlayerSO : ScriptableObject
{
    public new string name;

    public bool isDead;
    public bool isDefending;

    public int actionPoints;

    public float maxHP;
    public float currentHP;
    public float maxMana;
    public float currentMana;
    public float meleeDamage;
    public float rangedDamage;
    public float magic1Damage;
    public float magic1ManaCost;
    public float magic2Damage;
    public float magic2ManaCost;
    public float critChance;
    public float critDamage;
    public float defense;
    public float healing;

    public GameObject prefab;

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
