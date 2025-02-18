using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    //private int currentScore = 0;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    public PlayerController player;

    protected void Awake()
    {
        gameManager = this;
        player = GetComponent<PlayerController>();
        uiManager = FindObjectOfType<UIManager>();
    }
/*
    public void ResultMiniGame()
    {
        uiManager.SetResultMainScene();
    }*/

}
