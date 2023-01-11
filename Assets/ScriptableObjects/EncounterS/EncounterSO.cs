using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EncounterSO", menuName = "ScriptableObjects/Encounter")]

public class EncounterSO : ScriptableObject
{
    public new string name;
    public bool isBossEncounter;

    public int index;

    public float difficultyModifier;

    public EnemySO enemy;

    public GameObject prefab;
}
