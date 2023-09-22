using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    void Start()
    {
        health = 100;
        attack = 5;
        speed = 1.0f;

        animator.runtimeAnimatorController 
            = (RuntimeAnimatorController)Resources.Load("Enemy Unit Animator");
    }

    public void Damage()
    {
        target.GetComponent<MyUnit>().Hit(attack);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MyUnit"))
        {
            target = other;
            state = State.ATTACK;
        }
    }


}
