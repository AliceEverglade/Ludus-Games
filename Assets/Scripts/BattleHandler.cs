using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    private TestStatsEnemy playerStats;
    private TestStatsEnemy enemy1Stats;

    [SerializeField] private Transform playerStation;
    [SerializeField] private Transform enemyStation_1;
    [SerializeField] private Transform enemyStation_2;
    [SerializeField] private Transform enemyStation_3;

    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Slider playerHP;
    [SerializeField] private Slider enemy1HP;
    [SerializeField] private Slider enemy2HP;
    [SerializeField] private Slider enemy3HP;

    [SerializeField] private BattleState state;
    private enum BattleState
    {
        Start, 
        PlayerTurn, 
        EnemyTurn,
        Won, 
        Lost, 
        Busy
    }
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        StartCoroutine(Setup());
    }
    private IEnumerator Setup()
    {
        GameObject playerGO = Instantiate(player,playerStation);
        playerStats = playerGO.GetComponent<TestStatsEnemy>();
        GameObject enemy1GO = Instantiate(enemy,enemyStation_1);
        enemy1Stats = enemy1GO.GetComponent<TestStatsEnemy>();

        dialogueText.text = "the battle has begun.";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Player turn:";
        yield return new WaitForSeconds(1f);
        state = BattleState.PlayerTurn;
        PlayerTurn();
    }

    private void PlayerTurn()
    {
        dialogueText.text = "choose an action:";
    }

    public void onAttackButton()
    {
        if(state != BattleState.PlayerTurn)
            return;

        StartCoroutine(PlayerAttack());
    }
    public void onHealButton()
    {
        if (state != BattleState.PlayerTurn)
            return;

        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerAttack()
    {
        //damage enemy
        enemy1Stats.isDead = enemy1Stats.TakeDamage(playerStats.damage);
        yield return new WaitForSeconds(2f);
        if (enemy1Stats.isDead)
        {
            state = BattleState.Won;
            EndBattle();
        }
        else
        {
            state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerHeal()
    {
        playerStats.Heal(50);
        dialogueText.text = "you healed yourself.";
        yield return new WaitForSeconds(1f);
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = "Enemy Attacks!";
        yield return new WaitForSeconds(1f);
        playerStats.isDead = playerStats.TakeDamage(enemy1Stats.damage);
        if (playerStats.isDead)
        {
            state = BattleState.Lost;
            EndBattle();
        }
        else
        {
            state = BattleState.PlayerTurn;
            PlayerTurn();
        }
    }


    private void EndBattle()
    {
        if(state == BattleState.Won)
        {
            dialogueText.text = "you've won!";
            // show upgrades, then go to next level
        }
        else if(state == BattleState.Lost)
        {
            dialogueText.text = "you lost :C";
            // go to home screen
        }
    }
}
