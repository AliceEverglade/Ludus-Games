using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;

    [SerializeField] private GameStateSO index;
    private EncounterSO encounter;
    private PlayerSO playerStats;
    private EnemySO enemy1Stats;
    private EnemySO enemy2Stats;

    private int target = 1;

    [SerializeField] private Transform playerStation;
    [SerializeField] private Transform enemyStation_1;
    [SerializeField] private Transform enemyStation_2;

    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Slider playerHP;
    [SerializeField] private Slider enemy1HP;
    [SerializeField] private Slider enemy2HP;

    [SerializeField] private BattleState state;
    private enum BattleState
    {
        Start, 
        PlayerTurn, 
        Enemy1Turn,
        Enemy2Turn,
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
        GameObject playerGO = Instantiate(player, playerStation);
        playerStats = playerGO.GetComponent<PlayerSO>();
        enemy1 = encounter.enemy1.prefab;
        GameObject enemy1GO = Instantiate(enemy1, enemyStation_1);
        enemy1Stats = enemy1GO.GetComponent<EnemySO>();
        enemy2 = encounter.enemy2.prefab;
        GameObject enemy2GO = Instantiate(enemy2, enemyStation_2);
        enemy2Stats = enemy2GO.GetComponent<EnemySO>();

        

        dialogueText.text = "the battle has begun.";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Player turn:";
        yield return new WaitForSeconds(1f);
        state = BattleState.PlayerTurn;
        PlayerTurn();
    }

    private void PlayerTurn()
    {
        dialogueText.text = "you have " + playerStats.actionPoints + " left.";
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
        //target Enemy
        if(target == 1)
        {
            
        }
        //damage enemy
        enemy1Stats.isDead = enemy1Stats.TakeDamage(playerStats.meleeDamage);
        yield return new WaitForSeconds(2f);
        if (enemy1Stats.isDead)
        {
            state = BattleState.Won;
            EndBattle();
        }
        else
        {
            state = BattleState.Enemy1Turn;
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
