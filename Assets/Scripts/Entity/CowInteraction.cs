using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CowInteraction : MonoBehaviour, IInteractable
{
    GameObject _gameObject;

    public void Interact()
    {
        _gameObject = transform.gameObject;
        Debug.Log(_gameObject.name + "��(��) ��ȣ�ۿ��߽��ϴ�!");

        GameManager.instance.Action(_gameObject);
    }
}
