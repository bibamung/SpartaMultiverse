using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class B_GameManager : MonoBehaviour
{
    public GameObject meatPrefab; // ��� ������
    public float spawnInterval = 1f; // ��� ���� ���� (��)
    public float limitTime = 30; // ���ѽð�
    private bool isGameRunning = true; // ������ ���� ������ ����
    private List<GameObject> activeMeats = new List<GameObject>(); // Ȱ��ȭ�� ��� ������Ʈ ����Ʈ

    public GameObject gameOverPanel;
   
    void Start()
    {
        StartCoroutine(GameTimer());
        StartCoroutine(SpawnMeat());
    }
    IEnumerator GameTimer()
    {
        // ���� ���� �ð� ���� ���
        yield return new WaitForSeconds(limitTime);

        // ���� ����
        isGameRunning = false;

        gameOverPanel.SetActive(true);

        Debug.Log("Game Over!");
    }

    IEnumerator SpawnMeat()
    {
        while (isGameRunning)
        {
            // ��� ������Ʈ ����
            Instantiate(meatPrefab, GetRandomStartPosition(), Quaternion.identity);
            Instantiate(meatPrefab, GetRandomStartPosition(), Quaternion.identity);

            // ���� ��� �������� ���
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector2 GetRandomStartPosition()
    {
        // ������ ���� ��ġ ���� (���� �Ǵ� ����)
        float x = Random.Range(0, 2) == 0 ? -16f : 16f;
        float y = Random.Range(-5f, 5f); // Y��ǥ�� ����
        return new Vector2(x, y);
    }

}