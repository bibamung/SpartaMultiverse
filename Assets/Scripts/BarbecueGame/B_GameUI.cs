using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class B_GameUI : MonoBehaviour
{
    int player1;
    int player2;

    public TMP_Text player1Score;
    public TMP_Text player2Score;

    private float limitTime = 30;
    public TMP_Text time;

    private void Update()
    {
        player1Score.text = player1.ToString();
        player2Score.text = player2.ToString();

        if (limitTime >= 0)
        {
            limitTime -= Time.deltaTime;
        }
        else
        {
            limitTime = 0;
        }
        time.text = limitTime.ToString("N1");
    }

    public void AddScore(string name ,int score)
    {
        if (name == "Player1")
        {
            player1 += score;
        }
        else
        {
            player2 += score;
        }
        
    }

    public string WinPlayer()
    {
        if (player1 > player2)
        {
            return "Player1";
        }
        else if (player1 < player2)
        {
            return "Player2";
        }
        else
        {
            return "Draw";
        }

    }

}
