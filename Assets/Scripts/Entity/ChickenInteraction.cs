using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenInteraction : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log(gameObject.name + "��(��) ��ȣ�ۿ��߽��ϴ�!");
        SceneManager.LoadScene("MiniGameScene");
    }
}
