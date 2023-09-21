using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observe : MonoBehaviour
{
    public GameObject target;

    // 커스텀 코루틴
    // URinx
    WaitForSeconds wait = new WaitForSeconds(1f);

    public void EarthObservation()
    {
        StartCoroutine(LookCoroutine());
    }

    public IEnumerator LookCoroutine()
    {
        transform.LookAt(target.transform);

        yield return wait;

        transform.rotation = Quaternion.Euler(15f, 90f, 0);
    }
   
}
