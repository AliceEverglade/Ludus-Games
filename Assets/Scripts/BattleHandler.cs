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
    [SerializeField] private TestStatsEnemy playerStats;
    [SerializeField] private TestStatsEnemy enemy1Stats;

    [SerializeField] private Transform playerStation;
    [SerializeField] private Transform enemyStation_1;
    [SerializeField] private Transform enemyStation_2;
    [SerializeField] private Transform enemyStation_3;

    [SerializeField] private TMP_Text dialogueText;

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
        state = BattleState.PlayerTurn;
    }
}
