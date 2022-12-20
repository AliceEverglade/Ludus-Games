using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameStateSO gameState;
    private EncounterSO encounter;

    [SerializeField] private Slider hpBar;
    [SerializeField] private GameObject target;
    [SerializeField] private TMP_Text hpText;
    private void Start()
    {

    }

    private void Update()
    {
        SetUI();
    }

    public void SetUI()
    {
        Debug.Log(target.name);
        switch (target.name)
        {
            case "PlayerStation":

                break;
            case "EnemyStation_1":
                break;
        }
            hpBar.maxValue = target.GetComponentInChildren<TestStatsEnemy>().maxHP;
            hpBar.value = target.GetComponentInChildren<TestStatsEnemy>().currentHP;
            hpText.text = target.GetComponentInChildren<TestStatsEnemy>().currentHP.ToString();
    }
}
