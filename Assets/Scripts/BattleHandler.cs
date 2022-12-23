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

    [SerializeField] private GameStateSO gameState;
    private EncounterSO encounter;
    private PlayerSO playerStats;
    private EnemySO enemy1Stats;
    private EnemySO enemy2Stats;
    private EnemySO target;

    private bool targetEnemy1 = true;

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
        //encounter init
        encounter = gameState.EncounterList[gameState.EncounterIndex-1];
        Debug.Log("Encounter Loaded. number: " + gameState.EncounterIndex);

        //player init
        playerStats = gameState.player;
        player = playerStats.prefab;
        GameObject playerGO = Instantiate(player, playerStation);
        Debug.Log(playerStats.name + " loaded");


        //enemy 1 init
        enemy1Stats = encounter.enemy1;
        enemy1 = enemy1Stats.prefab;
        GameObject enemy1GO = Instantiate(enemy1, enemyStation_1);
        

        //enemy 2 init
        enemy2Stats = encounter.enemy2;
        enemy2 = enemy2Stats.prefab;
        GameObject enemy2GO = Instantiate(enemy2, enemyStation_2);
        

        

        dialogueText.text = "the battle has begun.";
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Player turn:";
        yield return new WaitForSeconds(1f);
        state = BattleState.PlayerTurn;
        PlayerTurn();
    }

    private void PlayerTurn()
    {
        if (playerStats.actionPoints > 0)
        {
            dialogueText.text = "you have " + playerStats.actionPoints + " Action Points left.";
        }
        else
        {
            EnemyTurn();
        }
        
    }

    #region button functions
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
    public void OnDefenseButton()
    {
        if (state != BattleState.PlayerTurn)
            return;

        StartCoroutine(PlayerDefense());
    }
    public void onRunButton()
    {
        if (state != BattleState.PlayerTurn)
            return;
        StartCoroutine(PlayerRun());
    }
    #endregion

    #region action enumerators
    IEnumerator PlayerAttack()
    {
        //target Enemy
        if(target)
        {
            
        }
        //damage enemy
        enemy1Stats.isDead = enemy1Stats.TakeDamage(playerStats.meleeDamage);
        yield return new WaitForSeconds(2f);
        if (enemy1Stats.isDead && enemy2Stats.isDead)
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
        playerStats.Heal();
        dialogueText.text = "you healed yourself.";
        yield return new WaitForSeconds(1f);
    }

    IEnumerator PlayerDefense()
    {
        playerStats.Defense();
        dialogueText.text = "you defended yourself.";
        yield return new WaitForSeconds(1f);
    }

    IEnumerator PlayerRun()
    {
        dialogueText.text = "you ran from the battle";
        gameState.EndBattle(false);
        yield return new WaitForSeconds(3f);
    }
    #endregion


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
