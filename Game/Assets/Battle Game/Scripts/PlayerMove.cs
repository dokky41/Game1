using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private bool isMoving = true; // �̵� ���¸� ��Ÿ���� ����

    // monsterObject ������Ʈ ����
    private GameObject monsterObject;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();

        // Player ������Ʈ ã�� (�̸��� �������)
        monsterObject = GameObject.Find("Monster");
    }

    // Update is called once per frame
    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (!isMoving)
        {
            // "isAttacking" �Ҹ� �Ķ���͸� true�� �����Ͽ� ���� �ִϸ��̼��� �����մϴ�.
            animator.SetBool("isAttacking", true);
        }


        // monster ������Ʈ�� Animator ������Ʈ���� "isDead" �Ķ���Ͱ� true���� Ȯ��
        bool monsterIsAttacking = monsterObject.GetComponent<Animator>().GetBool("isDead");

        if (monsterIsAttacking)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
           
        }



    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            // �浹�� ������Ʈ�� �±װ� "Obstacle"�� �� �̵��� ����ϴ�.
            isMoving = false;
        }
    }

}
