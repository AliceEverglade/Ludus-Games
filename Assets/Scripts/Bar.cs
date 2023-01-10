using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bar : MonoBehaviour
{
    [SerializeField] private GameStateSO gameState;
    private EncounterSO encounter;
    private PlayerSO playerStats;
    private EnemySO enemy1Stats;
    private EnemySO enemy2Stats;


    [SerializeField] private GameObject target;
    [SerializeField] private Slider barSlider;
    [SerializeField] private TMP_Text barText;
    private void Start()
    {
        encounter = gameState.EncounterList[gameState.EncounterIndex - 1];
        playerStats = gameState.player;
        enemy1Stats = encounter.enemy;
    }

    private void Update()
    {
        SetUI();
    }

    public void SetUI()
    {
        switch (target.name)
        {
            case "PlayerStation":
                barSlider.maxValue = playerStats.maxHP;
                barSlider.value = playerStats.currentHP;
                barText.text = barSlider.value.ToString();
                break;
            case "EnemyStation":
                barSlider.maxValue = enemy1Stats.maxHP;
                barSlider.value = enemy1Stats.currentHP;
                barText.text = barSlider.value.ToString();
                break;
        }
    }
}
