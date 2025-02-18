using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class F_GameOverUI : F_BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private TextMeshProUGUI BestScore;
    [SerializeField] private TextMeshProUGUI currentScore;

    

    public override void Init(FlappyUIManager uIManager)
    {
        base.Init(uIManager);
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickExitButton()
    {
        MiniGameManager.isFirstLoading = true;
        string previousScene = PlayerPrefs.GetString("PreviousScene", "DefaultScene");
        PlayerPrefs.SetInt("HasPlayedMiniGame", 1);

        // 원래 씬으로 돌아가기
        SceneManager.LoadScene(previousScene);
    }
    public void UpdateCurScore(int score)
    {
        currentScore.text = score.ToString();
    }
    public void UpdateBestScore(int score)
    {
        BestScore.text = PlayerPrefs.GetInt("Flappy_BestScore").ToString();
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }

}
