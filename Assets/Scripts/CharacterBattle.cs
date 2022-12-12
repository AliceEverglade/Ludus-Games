 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private Animator Anim;
    
    private void Awake()
    {
        Anim = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void MeleeAttack(GameObject target)
    {
        Anim.SetBool("isAttacking", true);
        //get target's hp, subtract damage from it.
        //play hurt animation from target.
        //apply any effects the melee attack has.
    }

    public void FinishAttack(string attackType)
    {
        //set back to idle
        //Anim.SetBool(attackType, false);
        Anim.SetBool("isAttacking", false);
    }
}
