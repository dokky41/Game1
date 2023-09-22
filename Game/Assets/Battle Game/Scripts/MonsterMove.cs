using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMove : MonoBehaviour
{
    private Animator animator;
    private bool isMoving = true; // �̵� ���¸� ��Ÿ���� ����
    private bool hasAttacked = false;

    //ü�¹�
    private GameObject m_goHpBar;
    private float m_fSpeed = 5.0f;

    // Slider ���� �߰�
    private Slider hpSlider;
    private float currentHp = 100.0f; // ���� HP
    private float maxHp = 100.0f; // �ִ� HP

    // Player ������Ʈ ����
    private GameObject playerObject;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();

        //ü�¹�
        // Canvas���� Slider ������Ʈ ã��
        m_goHpBar = GameObject.Find("Canvas/Slider");
        // Slider ������Ʈ ��������
        hpSlider = m_goHpBar.GetComponent<Slider>();
        // �ʱ� HP ����
        hpSlider.value = currentHp / maxHp;

        // Player ������Ʈ ã�� (�̸��� �������)
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
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

        if(!isMoving && hpSlider.value <= 0)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isDead", true);
        }


      // Player ������Ʈ�� Animator ������Ʈ���� "isAttacking" �Ķ���Ͱ� true���� Ȯ��
      bool playerIsAttacking = playerObject.GetComponent<Animator>().GetBool("isAttacking");
      
      if (playerIsAttacking)
      {
          // �÷��̾ ���� ���� ������ TakeDamage �Լ� ȣ���Ͽ� ü�� ����
          float damageAmount = maxHp * 0.001f; // �ִ� ü���� 10%�� �������� ����
          TakeDamage(damageAmount);
      }


        //ü��  
        // ������Ʈ�� ���� HP Bar ��ġ �̵�
        m_goHpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(-0.2f, 3f, 0));

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �浹�� ������Ʈ�� �±װ� "Player"�� �� �̵��� ����ϴ�.
            isMoving = false;
        }
    }

    // HP ���� �Լ�
    void TakeDamage(float damageAmount)
    {
        currentHp -= damageAmount;

        // Slider�� value �� ������Ʈ
        hpSlider.value = currentHp / maxHp;

        if (currentHp <= 0)
        {
            // ���Ͱ� �׾��� ���� ó��
            Die();
        }
    }

  


    void Die()
    {
        // ���Ͱ� �׾��� ���� ����
    }

}
