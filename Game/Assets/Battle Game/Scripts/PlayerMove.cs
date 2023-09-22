using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private bool isMoving = true; // 이동 상태를 나타내는 변수

    // monsterObject 오브젝트 참조
    private GameObject monsterObject;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();

        // Player 오브젝트 찾기 (이름을 기반으로)
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
            // "isAttacking" 불린 파라미터를 true로 설정하여 공격 애니메이션을 시작합니다.
            animator.SetBool("isAttacking", true);
        }


        // monster 오브젝트의 Animator 컴포넌트에서 "isDead" 파라미터가 true인지 확인
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
            // 충돌한 오브젝트의 태그가 "Obstacle"일 때 이동을 멈춥니다.
            isMoving = false;
        }
    }

}
