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
        switch (EncounterIndex)
        {
            case 1:
                if (didWin)
                {
                    EncounterIndex++;
                    SceneManager.LoadScene("Fight");
                }
                else
                {
                    EncounterIndex = 1;
                    SceneManager.LoadScene("Map");
                }
                break;
            case 2:
                if (didWin)
                {
                    EncounterIndex++;
                    SceneManager.LoadScene("Map");
                }
                else
                {
                    EncounterIndex = 1;
                    SceneManager.LoadScene("Map");
                }
                break;
            case 3:
                if (didWin)
                {
                    EncounterIndex++;
                    SceneManager.LoadScene("Fight");
                }
                else
                {
                    EncounterIndex = 3;
                    SceneManager.LoadScene("Map");
                }
                break;
            case 4:
                if (didWin)
                {
                    EncounterIndex++;
                    SceneManager.LoadScene("Map");
                }
                else
                {
                    EncounterIndex = 3;
                    SceneManager.LoadScene("Map");
                }
                break;
            case 5:
                if (didWin)
                {
                    EncounterIndex++;
                    SceneManager.LoadScene("Fight");
                }
                else
                {
                    EncounterIndex = 5;
                    SceneManager.LoadScene("Map");
                }
                break;
            case 6:
                if (didWin)
                {
                    EncounterIndex++;
                    SceneManager.LoadScene("Fight");
                }
                else
                {
                    EncounterIndex = 5;
                    SceneManager.LoadScene("Map");
                }
                break;
            case 7:
                if (didWin)
                {
                    EncounterIndex++;
                    SceneManager.LoadScene("Credits");
                }
                else
                {
                    EncounterIndex = 1;
                    SceneManager.LoadScene("Map");
                }
                break;
        }
    }
}
