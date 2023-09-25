using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Slider hpBar;


    public void CurrentHP(float hp, float maxHP)
    {
        // Unit 체력 / Unit Max 체력
        hpBar.value = hp / maxHP;
        Debug.Log("dd"+hpBar.value);
    }



}
