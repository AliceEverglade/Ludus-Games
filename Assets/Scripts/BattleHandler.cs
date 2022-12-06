using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    private static BattleHandler instance;
    public static BattleHandler GetInstance()
    {
        return instance;
    }

    [SerializeField] private Transform Enemy1;
    [SerializeField] private Transform SirNugget;

    private CharacterBattle PlayerCharacterBattle;
    private CharacterBattle EnemyCharacterBattle;
    private GameState state;

    private enum GameState
    {
        WaitingForPlayer,
        Busy,
    }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacterBattle = SpawnCharacter(true, SirNugget);
        EnemyCharacterBattle = SpawnCharacter(false, Enemy1);
        state = GameState.WaitingForPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.WaitingForPlayer)
        {
            if (Input.GetButtonDown("Confirm"))
            {
                Debug.Log("Player Attacked");
                //set state to busy, play Attack Animation and when done, return state to WaitingForPlayer
                state = GameState.Busy;
                PlayerCharacterBattle.Attack(EnemyCharacterBattle, () => { state = GameState.WaitingForPlayer; });
            }
        }
        
    }

    private CharacterBattle SpawnCharacter(bool isPlayerTeam, Transform character)
    {
        Vector3 position;
        if (isPlayerTeam)
        {
            position = new Vector3(-6f, 0, 0);
        }
        else
        {
            position = new Vector3(5, 0, 0);
        }
        Transform characterTransform =  Instantiate(character, position, Quaternion.identity);
        CharacterBattle characterBattle = characterTransform.GetComponent<CharacterBattle>();

        return characterBattle;
    }
}
