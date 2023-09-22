using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    RUN,
    ATTACK,
    DIE
}

[RequireComponent(typeof(Animator))]
public abstract class Unit : MonoBehaviour
{
    protected float health;
    protected float attack;
    protected float speed;

    protected Collider target;
    protected Animator animator;

    protected State state;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.RUN: Move();

                break;
            case State.ATTACK: Attack();

                break;
            case State.DIE: DIE();

                break;
        }            
    }

    protected virtual void Move()
    {
        animator.SetBool("Attack", false);
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    protected virtual void Attack()
    {
        speed = 0.0f;
        animator.SetBool("Attack", true);
    }

    protected virtual void DIE()
    {
        animator.Play("Die");
        Destroy(gameObject);
    }


    public void Hit(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            state = State.DIE;
        }
    }


}
