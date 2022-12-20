using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStateSO", menuName = "ScriptableObjects/GameState")]
public class GameStateSO : ScriptableObject
{
    public int EncounterIndex;
    public List<EncounterSO> EncounterList;
}
