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

        GameManager.instance.Action(_gameObject);
    }

    public void Interact(PlayerController player)
    {
        //
    }
}
