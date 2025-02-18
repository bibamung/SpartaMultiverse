using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class F_HomeUI : F_BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    

    public override void Init(FlappyUIManager uIManager)
    {
        base.Init(uIManager);
        Time.timeScale = 0;
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }
    public void OnClickStartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickExitButton()
    {
        MiniGameManager.isFirstLoading = true;
        string previousScene = PlayerPrefs.GetString("PreviousScene", "DefaultScene");

        Time.timeScale = 1;

        // 원래 씬으로 돌아가기
        SceneManager.LoadScene(previousScene);
    }

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
}
