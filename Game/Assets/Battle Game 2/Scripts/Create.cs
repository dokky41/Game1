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
             prefab[index], // 생성할 게임 오브젝트
             createPosition[index].position,
             prefab[index].transform.rotation
        );
    }


}
