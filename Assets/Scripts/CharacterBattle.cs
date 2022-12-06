using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private Animator Anim;

    private CharacterState state;
    private enum CharacterState
    {
        Idle,
        Sliding,
        casting,
        busy
    }

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        state = CharacterState.Idle;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(bool isPlayerTeam)
    {
        //set idle anim or spawning anim
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Attack(CharacterBattle target, Action onAttackComplete)
    {
        Vector3 attackDir = target.GetPosition() - GetPosition().normalized;
        Debug.Log(target.name);
        //play attack animation
        Anim.SetBool("isAttacking", true);
        // when done go back to idle
        onAttackComplete();
    }

    public void FinishAttack()
    {
        Anim.SetBool("isAttacking", false);
    }
}
