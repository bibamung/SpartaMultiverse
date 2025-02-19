using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    static MiniGameManager miniGameManager;
    public static MiniGameManager Instance { get { return miniGameManager; } }

    private int currentScore = 0;

    FlappyUIManager uiManager;
    public FlappyUIManager UIManager { get { return uiManager; } }

    public static bool isFirstLoading  = true;
    public bool IsFirstLoading { get; set; }

    public FlappyPlayer player;


    private void Awake()
    {
        miniGameManager = this;
        uiManager = FindObjectOfType<FlappyUIManager>();
    }

    private void Start()
    {
        if (!isFirstLoading)
        {
            StartGame();
        }
        else
        {
            isFirstLoading = false;
        }
        
    }

    public void StartGame()
    {
        uiManager.SetPlayGame();
    }

    public void GameOver()
    {
        if (PlayerPrefs.HasKey("Flappy_BestScore"))
        {
            if(PlayerPrefs.GetInt("Flappy_BestScore") < currentScore)
            {
                PlayerPrefs.SetInt("Flappy_BestScore", currentScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Flappy_BestScore", currentScore);
        }
        PlayerPrefs.SetInt("Flappy_LastScore",currentScore);
        uiManager.ChangeCurrentScore(currentScore);
        uiManager.ChangeBestScore(PlayerPrefs.GetInt("Flappy_BestScore"));
        uiManager.SetRestart();
    }



    public void AddScore(int score)
    {
        if (player.isDead)
        {
            return;
        }
        currentScore += score;
        Debug.Log($"Score: {currentScore}");
        uiManager.ChangeScore(currentScore);
    }
}
