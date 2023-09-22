using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUnit : Unit
{
    
    void Start() 
    {
        health = 100;
        attack = 10;
        speed = 1.0f;


        animator.runtimeAnimatorController
           = (RuntimeAnimatorController)Resources.Load("My Unit Animator");
    }
    public void Damage()
    {
        target.GetComponent<EnemyUnit>().Hit(attack);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyUnit"))
        {
            target = other;
            state = State.ATTACK;
        }
    }



}
