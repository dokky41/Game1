using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{

    public GameObject [] prefab;
    public Transform[] createPosition;

    public void CreateUnit(int index)
    {
        Instantiate
        (
             prefab[index], // ������ ���� ������Ʈ
             createPosition[index].position,
             prefab[index].transform.rotation
        );
    }


}
