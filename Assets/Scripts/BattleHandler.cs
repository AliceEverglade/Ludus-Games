using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject enemy;

    [SerializeField] private GameStateSO gameState;
    private EncounterSO encounter;
    private PlayerSO playerStats;
    private EnemySO enemyStats;

    [SerializeField] private Transform playerStation;
    [SerializeField] private Transform enemyStation;
    private Animator playerAnim;
    private Animator enemyAnim;

    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text encounterNameText;
    //private TMP_Text playerNameText;
    //private TMP_Text enemyNameText;
    [SerializeField] private Slider playerHP;
    [SerializeField] private Slider enemyHP;

    [SerializeField] private GameObject winPrefab;
    [SerializeField] private GameObject losePrefab;

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
        //encounter init
        encounter = gameState.EncounterList[gameState.EncounterIndex-1];
        Debug.Log("Encounter Loaded. number: " + gameState.EncounterIndex);
        if(encounter.prefab != null)
        {
            Vector3 offset = encounter.prefab.transform.position;
            Instantiate(encounter.prefab , transform.position + offset, Quaternion.identity, transform);
        }
        
        encounterNameText.text = encounter.name;

        //player init
        playerStats = gameState.player;
        player = playerStats.prefab;

        GameObject playerGO = Instantiate(player, 
            new Vector3(playerStation.position.x, 
            playerStation.position.y, 
            playerStation.position.z) + playerStats.offset, 
            Quaternion.identity);

        playerAnim = playerGO.GetComponent<Animator>();
        Debug.Log(playerStats.name + " loaded");
        playerStats.currentHP = playerStats.maxHP;
        playerStats.currentMana = playerStats.maxMana;
        playerStats.currentDefense = 0;
        playerStats.isDead = false;


        //enemy init
        enemyStats = encounter.enemy;
        enemy = enemyStats.prefab;

        GameObject enemy1GO = Instantiate(enemy, 
            new Vector3(enemyStation.position.x, 
            enemyStation.position.y, 
            enemyStation.position.z) + enemyStats.offset, 
            Quaternion.identity);
        if(enemy1GO.GetComponent<Animator>() != null)
        {
            enemyAnim = enemy1GO.GetComponent<Animator>();
        }

        Debug.Log(enemyStats.name + " loaded");
        enemyStats.currentHP = enemyStats.maxHP;
        enemyStats.isDead = false;



        if (enemyStats.isBoss)
        {
            dialogueText.text = "the Boss battle has begun.";
        }
        else
        {
            dialogueText.text = "the battle has begun.";
        }
        
        yield return new WaitForSeconds(2f);
        dialogueText.text = "Player turn:";
        yield return new WaitForSeconds(0.5f);
        state = BattleState.PlayerTurn;
        PlayerTurn();
    }

    private void PlayerTurn()
    {
        playerStats.StartTurn();
        actions();
    }
    private void actions()
    {
        if (playerStats.currentActionPoints > 0)
        {
            dialogueText.text = "you have " + playerStats.currentActionPoints + " Action Points left.";
        }
        else
        {
            state = BattleState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

    #region button functions
    public void onAttackButton()
    {
        Debug.Log("attack button clicked");
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
        Debug.Log("attack initiated");
        dialogueText.text = "you attack!";
        playerStats.currentActionPoints--;
        playerAnim.SetTrigger("Attack");
        enemyStats.isDead = playerStats.DealDamage(enemyStats,playerStats.meleeDamage);
        yield return new WaitForSeconds(0.2f);
        if(enemyAnim != null)
        {
            enemyAnim.SetTrigger("TakeDamage");
        }
        
        if (enemyStats.isDead)
        {
            state = BattleState.Won;
            EndBattle();
        }
        else
        {
            actions();
        }
    }

    IEnumerator PlayerHeal()
    {
        playerStats.currentActionPoints--;
        playerStats.Heal();
        playerAnim.SetTrigger("Magic");
        dialogueText.text = "you healed yourself.";
        yield return new WaitForSeconds(1f);
        actions();
    }

    IEnumerator PlayerDefense()
    {
        playerStats.currentActionPoints--;
        playerStats.Defense();
        playerAnim.SetTrigger("Magic");
        dialogueText.text = "you defended yourself.";
        yield return new WaitForSeconds(1f);
        actions();
    }

    IEnumerator PlayerRun()
    {
        dialogueText.text = "you ran from the battle";
        state = BattleState.Lost;
        EndBattle();
        yield return new WaitForSeconds(3f);
    }
    #endregion


    IEnumerator EnemyTurn()
    {
        enemyStats.StartTurn();
        while(enemyStats.currentActionPoints > 0)
        {
            dialogueText.text = "Enemy Attacks!";
            if(enemyAnim != null)
            {
                enemyAnim.SetTrigger("Attack");
            }
            
            yield return new WaitForSeconds(0.2f);
                playerAnim.SetTrigger("TakeDamage");
            yield return new WaitForSeconds(1f);
            enemyStats.currentActionPoints--;

            enemyStats.DealDamage(playerStats,enemyStats.damage);
            dialogueText.text = "you take: " + enemyStats.damage + " damage";
            yield return new WaitForSeconds(1f);
            if (playerStats.isDead)
            {
                state = BattleState.Lost;
                EndBattle();
            }
        }
        if(enemyStats.currentActionPoints <= 0)
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
            StartCoroutine(EndBattleScene(winPrefab, true));
            // show upgrades, then go to next level
        }
        else if(state == BattleState.Lost)
        {
            dialogueText.text = "you lost :C";
            StartCoroutine(EndBattleScene(losePrefab, false));
            // go to home screen
        }
    }

    private IEnumerator EndBattleScene(GameObject endScreen, bool didWin)
    {
        Vector3 offset = endScreen.transform.position;
        Instantiate(endScreen, transform.position + offset, Quaternion.identity, transform);
        yield return new WaitForSeconds(1);
        Debug.Log("go to next scene");
        gameState.EndBattle(didWin);
    }
}
