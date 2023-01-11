using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "GameStateSO", menuName = "ScriptableObjects/GameState")]
public class GameStateSO : ScriptableObject
{
    public PlayerSO player;
    public int EncounterIndex;
    public List<EncounterSO> EncounterList;

    public void EndBattle(bool didWin)
    {
        //set index
        //load next scene, Map or Fight depending on the scenario
        if (!didWin)
        {
            SetIndexOnLose();
            SceneManager.LoadScene("Map");
        }
        else
        {
            bool nextFight = SetIndexOnWin();
            if (nextFight)
            {
                SceneManager.LoadScene("Fight");
            }
            else
            {
                SceneManager.LoadScene("Map");
            }
        }
    }

    private bool SetIndexOnWin()
    {
        switch (EncounterIndex)
        {
            case 1:
            case 4:
            case 7:
                EncounterIndex++;
                return true;
            case 2:
            case 3:
            case 5:
            case 6:
            case 8:
            case 9:
                EncounterIndex++;
                return false;
            case 10:
                EncounterIndex = 1;
                SceneManager.LoadScene("Credits");
                return false;
            default:
                return false;
        }
    }

    private void SetIndexOnLose()
    {
        switch (EncounterIndex)
        {
            case 1:
            case 2:
                EncounterIndex = 1;
                break;
            case 3:
                EncounterIndex = 3;
                break;
            case 4:
            case 5:
                EncounterIndex = 4;
                break;
            case 6:
                EncounterIndex = 6;
                break;
            case 7:
            case 8:
            case 9:
                EncounterIndex = 9;
                break;
            case 10:
                EncounterIndex = 10;
                break;
        }
    }
}
