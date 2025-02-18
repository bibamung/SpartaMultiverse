using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public F_GameOverUI gameOverUI;
    public F_HomeUI homeUI;
    public F_GameUI gameUI;
    private UIState currentState;



    private void Awake()
    {
        homeUI = GetComponentInChildren<F_HomeUI>(true);
        homeUI.Init(this);
        gameUI = GetComponentInChildren<F_GameUI>(true);
        gameUI.Init(this);
        gameOverUI = GetComponentInChildren<F_GameOverUI>(true);
        gameOverUI.Init(this);

        ChangeState(UIState.Home);
    }


    // Start is called before the first frame update
/*    void Start()
    {
        restartText.gameObject.SetActive(false);
    }*/
    public void SetPlayGame()
    {
        Time.timeScale = 1;
        ChangeState(UIState.Game);
    }

    public void SetRestart()
    {
        ChangeState(UIState.GameOver);        
    }

    public void ChangeScore(int score)
    {
        gameUI.UpdateScore(score);
    }

    public void ChangeCurrentScore(int score)
    {
        gameOverUI.UpdateCurScore(score);
    }
    public void ChangeBestScore(int score)
    {
        gameOverUI.UpdateBestScore(score);
    }

    /*    public void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }*/

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
    }
}
