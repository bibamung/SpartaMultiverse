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

    public GameObject resultPanel; // UI �г�

    void Start()
    {
        if (!PlayerPrefs.HasKey("HasPlayedMiniGame"))
        {
            resultPanel.SetActive(false);
            return;
        }

        // ����� ������ �ִٸ� UI ǥ��
        if (PlayerPrefs.HasKey("Flappy_LastScore"))
        {
            // UI�� ���� ǥ��
            bestScore.text =PlayerPrefs.GetInt("Flappy_BestScore").ToString();
            lastScore.text = PlayerPrefs.GetInt("Flappy_LastScore").ToString();

            // �г� Ȱ��ȭ
            resultPanel.SetActive(true);
        }
        else
        {
            resultPanel.SetActive(false);
        }
        PlayerPrefs.DeleteKey("MiniGamePlayed");
    }

    // UI �ݱ� ��ư ���
    public void CloseResultPanel()
    {
        PlayerPrefs.DeleteKey("HasPlayedMiniGame");
        resultPanel.SetActive(false);
    }
}
