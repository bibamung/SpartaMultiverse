using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameResultUI : MonoBehaviour
{
    [SerializeField] private Button confirmButton;
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private TextMeshProUGUI lastScore;
    /*private UIState currentState;

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);
        confirmButton.onClick.AddListener(OnClickConfirm);
    }
    public void OnClickConfirm()
    {
        Time.timeScale = 1;
    }

    public void UpdateLastScore(int score)
    {
        lastScore.text = PlayerPrefs.GetInt("Flappy_LastScore").ToString();
    }
    public void UpdateBestScore(int score)
    {
        BestScore.text = PlayerPrefs.GetInt("Flappy_BestScore").ToString();
    }

    protected override UIState GetUIState()
    {
        return UIState.Result;
    }*/

    public GameObject resultPanel; // UI 패널

    void Start()
    {
        if (!PlayerPrefs.HasKey("HasPlayedMiniGame"))
        {
            resultPanel.SetActive(false);
            return;
        }

        // 저장된 점수가 있다면 UI 표시
        if (PlayerPrefs.HasKey("Flappy_LastScore"))
        {
            // UI에 점수 표시
            bestScore.text =PlayerPrefs.GetInt("Flappy_BestScore").ToString();
            lastScore.text = PlayerPrefs.GetInt("Flappy_LastScore").ToString();

            // 패널 활성화
            resultPanel.SetActive(true);
        }
        else
        {
            resultPanel.SetActive(false);
        }
        PlayerPrefs.DeleteKey("MiniGamePlayed");
    }

    // UI 닫기 버튼 기능
    public void CloseResultPanel()
    {
        PlayerPrefs.DeleteKey("HasPlayedMiniGame");
        resultPanel.SetActive(false);
    }
}
