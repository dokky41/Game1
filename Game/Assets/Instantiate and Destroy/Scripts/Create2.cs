using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create2 : MonoBehaviour
{
    public Button button;
    public GameObject prefab;

    private bool active = true;
    private float currentTime = 5.0f;

    public void CreateGeneric()
    {
        active = false;

        Instantiate
        (
            prefab, // 생성할 게임 오브젝트
            new Vector3(0, -1.25f, 0),
            prefab.transform.rotation
        ).AddComponent<Delete>();
    }


    private void Update()
    {
        if (active == false)
        {
            button.interactable = false;
            currentTime -= Time.deltaTime;
            button.image.fillAmount = currentTime / 5f;

            if(currentTime <= 0)
            {
                active = true;
                button.interactable = true;
                button.image.fillAmount = currentTime = 5f;
            }


        }
    }


}
