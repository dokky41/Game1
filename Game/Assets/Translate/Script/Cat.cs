using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    public Vector3 direction;
    public float speed = 1.0f;

  
    void Update()
    {

        #region Input.GetKeyDown
        // Ű�� ������ ��
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //transform.position += new Vector3(0,0,1);
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //transform.position += new Vector3(-1, 0, 0);
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //transform.position += new Vector3(0, 0, -1);
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //transform.position += new Vector3(1, 0, 0);
        //}

        #endregion

        // Input.GetAxis :-1 ~ 1 ������ ���� ��ȯ�ϴ� �Լ��Դϴ�.
        direction.x = Input.GetAxis("Horizontal"); 
        direction.z = Input.GetAxis("Vertical");

        // v(������ġ) = v0(������ġ) + vt(vector��) 
        // v = v0 + vt  (����̵�����)
        // Time.deltaTime : �� �������� �Ϸ�Ǳ���� �ɸ� �ð�
        // ������ ���̸� ���ֺ���

        //������ ũ�⸦ 1�� 
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);



    }


}
