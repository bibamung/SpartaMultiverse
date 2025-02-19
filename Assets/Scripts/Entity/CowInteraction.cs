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
        Debug.Log(_gameObject.name + "와(과) 상호작용했습니다!");

        GameManager.instance.Action(_gameObject);
    }
}
