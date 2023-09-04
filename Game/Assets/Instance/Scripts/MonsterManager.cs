using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public int[] ints;


    void Start()
    {
        foreach(var i in ints)
            Debug.Log(i);
    }

   
    void Update()
    {
        
    }


}
