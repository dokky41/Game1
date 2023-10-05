using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        float distance = Input.GetAxisRaw("Mouse ScrollWheel") * -1 * 10;

        mainCamera.fieldOfView = Mathf.Clamp
        (
            mainCamera.fieldOfView,
            20f,
            60f
        );

        mainCamera.fieldOfView += distance;



    }
}
