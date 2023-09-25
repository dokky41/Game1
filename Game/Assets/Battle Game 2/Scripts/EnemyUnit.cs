using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{
    void Start()
    {
       
        health = 100;
        attack = 10;
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

    public override void Hit(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            state = State.DIE;
            target.GetComponent<MyUnit>().state = State.RUN;
        }

    }
}
