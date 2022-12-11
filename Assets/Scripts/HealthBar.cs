using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider hpBar;
    [SerializeField] private GameObject target;
    private void Start()
    {

    }

    private void Update()
    {
        SetUI();
    }

    private void SetUI()
    {
        hpBar.maxValue = target.GetComponent<TestStatsEnemy>().maxHP;
        hpBar.value = target.GetComponent<TestStatsEnemy>().currentHP / hpBar.maxValue;
    }
}
