using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcInteraction : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log(gameObject.name + "��(��) ��ȣ�ۿ��߽��ϴ�!");

        //���� �� ����
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerPrefs.SetFloat("PlayerPosX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", player.transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", player.transform.position.z);
        }

        SceneManager.LoadScene("BarbecueGameScene");
    }
}
