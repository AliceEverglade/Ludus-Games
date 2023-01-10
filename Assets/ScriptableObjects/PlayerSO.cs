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
    public int currentActionPoints;

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
    public float currentDefense;
    public float healing;

    public GameObject prefab;

    public void StartTurn()
    {
        //tick damage from effects
        Debug.Log("player turn started");
        currentActionPoints = actionPoints;
        currentDefense = 0;
    }

    public bool TakeDamage(float damage)
    {
        if(currentDefense > 0)
        {
            if(currentDefense < damage)
            {
                damage -= currentDefense;
                currentDefense = 0;
            }
            else
            {
                currentDefense -= damage;
                damage = 0;
            }
        }
        currentHP -= damage;
        return isDead = currentHP < 0 ? true : false;
    }

    public void Heal()
    {
        currentHP += healing;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void Defense()
    {
        currentDefense = defense;
    }
}
