using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapHandler : MonoBehaviour
{
    [SerializeField] private GameStateSO gameState;
    [SerializeField] private Button buttonForest;
    [SerializeField] private Button buttonDesert;
    [SerializeField] private Button buttonMountain;
    // Start is called before the first frame update
    void Start()
    {
        buttonDesert.interactable= false;
        buttonMountain.interactable= false;
    }

    // Update is called once per frame
    void Update()
    {
        // if encounterIndex >= 3 desert enable
        // if encounterIndex >= 5 mountain enable
        if (gameState.EncounterIndex >= 3)
        {
            buttonDesert.interactable = true;
        }
        if (gameState.EncounterIndex >= 5)
        {
            buttonMountain.interactable = true;
        }
        if (gameState.EncounterIndex < 3)
        {
            buttonDesert.interactable = false;
        }
        if (gameState.EncounterIndex < 5)
        {
            buttonMountain.interactable = false;
        }



    }
    public void StartBattle()
    {
        SceneManager.LoadScene("Fight");
    }
}
