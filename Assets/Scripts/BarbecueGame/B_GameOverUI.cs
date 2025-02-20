using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_GameOverUI : MonoBehaviour
{
    public TMP_Text winPlayer;

    public B_GameUI gameUI;

    private void Update()
    {
        winPlayer.text = gameUI.WinPlayer();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitButton()
    {
        string previousScene = PlayerPrefs.GetString("PreviousScene", "DefaultScene");

        // 원래 씬으로 돌아가기
        SceneManager.LoadScene(previousScene);
    }
    
}
