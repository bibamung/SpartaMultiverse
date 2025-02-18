using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum UIState
{
    Home,
    Game,
    GameOver,
    Result,
}
public class UIManager : MonoBehaviour
{
    MiniGameResultUI resultUI;
    private UIState currentState;

    /*private void Awake()
    {
        resultUI = GetComponentInChildren<MiniGameResultUI>(true);
        resultUI.Init(this);

        ChangeState(UIState.Result);
    }

    public void SetResultMainScene()
    {
        ChangeState(UIState.Result);
    }


    public void ChangeCurrentScore(int score)
    {
        resultUI.UpdateLastScore(score);
    }
    public void ChangeBestScore(int score)
    {
        resultUI.UpdateBestScore(score);
    }


    public void ChangeState(UIState state)
    {
        currentState = state;
        resultUI.SetActive(currentState);
    }*/

}
