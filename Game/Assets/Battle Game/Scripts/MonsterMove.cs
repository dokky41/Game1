using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterMove : MonoBehaviour
{
    private Animator animator;
    private bool isMoving = true; // 이동 상태를 나타내는 변수
    private bool hasAttacked = false;

    //체력바
    private GameObject m_goHpBar;
    private float m_fSpeed = 5.0f;

    // Slider 변수 추가
    private Slider hpSlider;
    private float currentHp = 100.0f; // 현재 HP
    private float maxHp = 100.0f; // 최대 HP

    // Player 오브젝트 참조
    private GameObject playerObject;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();

        //체력바
        // Canvas에서 Slider 오브젝트 찾기
        m_goHpBar = GameObject.Find("Canvas/Slider");
        // Slider 컴포넌트 가져오기
        hpSlider = m_goHpBar.GetComponent<Slider>();
        // 초기 HP 설정
        hpSlider.value = currentHp / maxHp;

        // Player 오브젝트 찾기 (이름을 기반으로)
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
            // "isAttacking" 불린 파라미터를 true로 설정하여 공격 애니메이션을 시작합니다.
            animator.SetBool("isAttacking", true);
        }

        if(!isMoving && hpSlider.value <= 0)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isDead", true);
        }


      // Player 오브젝트의 Animator 컴포넌트에서 "isAttacking" 파라미터가 true인지 확인
      bool playerIsAttacking = playerObject.GetComponent<Animator>().GetBool("isAttacking");
      
      if (playerIsAttacking)
      {
          // 플레이어가 공격 중일 때마다 TakeDamage 함수 호출하여 체력 감소
          float damageAmount = maxHp * 0.001f; // 최대 체력의 10%를 데미지로 설정
          TakeDamage(damageAmount);
      }


        //체력  
        // 오브젝트에 따른 HP Bar 위치 이동
        m_goHpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(-0.2f, 3f, 0));

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 충돌한 오브젝트의 태그가 "Player"일 때 이동을 멈춥니다.
            isMoving = false;
        }
    }

    // HP 감소 함수
    void TakeDamage(float damageAmount)
    {
        currentHp -= damageAmount;

        // Slider의 value 값 업데이트
        hpSlider.value = currentHp / maxHp;

        if (currentHp <= 0)
        {
            // 몬스터가 죽었을 때의 처리
            Die();
        }
    }

  


    void Die()
    {
        // 몬스터가 죽었을 때의 동작
    }

}
