using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] Image progressUI;
    
    public void NextScene()
    {
        StartCoroutine(LoadScene("Battle Game Scene2"));
    }

    private IEnumerator LoadScene(string name)
    {
        screen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        progressUI.fillAmount = 0;

        // allowSceneActivation : 씬 이동을 제어하는 변수

        // true -> 씬을 이동합니다.
        // false -> 씬을 이동하지 않습니다.
        operation.allowSceneActivation = false;

        float progress = 0;

        // isDone : 씬 로딩이 다 끝났는 지 확인하는 함수
        // true -> 씬 로딩이 다 끝난 상태
        // false -> 씬 로딩이 다 끝나지 않은 상태
        while (!operation.isDone)
        {
            progress = Mathf.MoveTowards(progress, operation.progress, 
                Time.deltaTime);

            progressUI.fillAmount = progress;

            // 0.9f에서 씬 로딩을 끝냅니다.
            if(progress >= 0.9f)
            {
                progressUI.fillAmount = 1f;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

    }


}
