using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class B_HomeUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;


    public void Init()
    {
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

        // ���� ������ ���ư���
        SceneManager.LoadScene(previousScene);
    }

}
