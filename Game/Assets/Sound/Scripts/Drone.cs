using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float speed = 55f;
    public Vector3 direction;


    void Start()
    {
        direction = transform.position;

        // ù ��° �Ű����� : �����Ű�� ���� �Լ�
        // �� ��° �Ű����� : �� �� �Ŀ� ����Ǵ� �ð�
        // �� ��° �Ű����� : �� �� ���� �ݺ��Ǵ� �ð�
        InvokeRepeating("NewPosition", 5, 5);
    }

    private void Update()
    {
        transform.Translate
        (
            Vector3.forward * speed * Time.deltaTime
         );
         


    }


    public void NewPosition()
    {
        transform.position = direction;
        transform.Find("Canvas").gameObject.SetActive(false);
    }


}