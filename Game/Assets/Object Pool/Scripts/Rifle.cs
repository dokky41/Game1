using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ObjectPoolManager.instance.GetQueue(Camera.main.ScreenPointToRay(Input.mousePosition).origin);
        }

    }


}
