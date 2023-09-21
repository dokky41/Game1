using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP_Bar : MonoBehaviour
{
    public Transform monster;
    public Slider hpbar;
    public float maxHp;
    public float currenthp;

    private void Update()
    {
        transform.position = monster.position + new Vector3(0, 0, 0);
        hpbar.value = currenthp / maxHp;

    }



}
