using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    RUN,
    ATTACK,
    DIE
}

[RequireComponent(typeof(HPBar))]
[RequireComponent(typeof(Animator))]
public abstract class Unit : MonoBehaviour
{
    protected float maxHP;
    protected float health;
    protected float attack;
    protected float speed;

    protected HPBar hpBar;
    protected Collider target;
    protected Animator animator;


    public State state;

    private void Awake()
    {
        hpBar = GetComponent<HPBar>();


        animator = GetComponent<Animator>();
    }

    void Update()
    {
        switch (state)
        {
            case State.RUN:
                Move();
                break;
            case State.ATTACK:
                Attack();
                break;
            case State.DIE:
                Die();
                break;
        }
    }

    protected virtual void Move()
    {
        speed = 1.0f;
        animator.SetBool("Attack", false);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected virtual void Attack()
    {
        speed = 0.0f;
        animator.SetBool("Attack", true);
    }

    protected virtual void Die()
    {
        animator.Play("Die");
        Destroy(gameObject);
    }

    public abstract void Hit(float damage);







}