using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class F_BaseUI : MonoBehaviour
{
    protected FlappyUIManager f_uiManager;
    protected UIManager uiManager;

    public virtual void Init(FlappyUIManager uiManager)
    {
        this.f_uiManager = uiManager;
    }
    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }


    protected abstract UIState GetUIState();
    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}
