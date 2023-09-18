using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    [SerializeField] List<GameObject> units;

    public static Action action;

    private int select = 0;

    private void Awake()
    {
        SelectUnit();
        action = RegisterUnit;
    }

    public void SelectUnit(int select = 0)
    {
        for (int i = 0; i < units.Count; i++)
        {
            if (select == i)
            {
                this.select = select;
                units[select].SetActive(true);
            }
            else
            {
                units[i].SetActive(false);
            }
        }
    }

    public void RegisterUnit()
    {
        DontDestroyOnLoad(units[select]);
    }

}