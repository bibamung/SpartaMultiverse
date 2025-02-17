using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenInteraction : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log(gameObject.name + "와(과) 상호작용했습니다!");
        SceneManager.LoadScene("MiniGameScene");
    }
}
