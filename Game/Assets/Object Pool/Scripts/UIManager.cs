using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text currentScoreText;
    

    private void Start()
    {
        scoreText.text = "Best Score : " + DataManager.instance.Score;
    }

    public void IncreaseScore()
    {
        DataManager.instance.CurentScore += 100;

        if(PlayerPrefs.GetInt("SCORE") <= DataManager.instance.CurentScore)
        {
            scoreText.text = "Best Score : " + DataManager.instance.Score;
            DataManager.instance.Score = DataManager.instance.CurentScore;
        }

        currentScoreText.text = "Current Score : " + DataManager.instance.CurentScore;

        DataManager.instance.Save();
    }


}
