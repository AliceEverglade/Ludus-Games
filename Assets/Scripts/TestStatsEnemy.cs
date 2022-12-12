using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStatsEnemy : MonoBehaviour
{
    public string unitName;

    public int damage;
    public int maxHP;
    public int currentHP;
    public bool isDead;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        return currentHP <= 0 ? true : false;
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
