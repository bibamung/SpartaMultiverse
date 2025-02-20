using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class B_GameManager : MonoBehaviour
{
    public GameObject meatPrefab; // 고기 프리팹
    public float spawnInterval = 1f; // 고기 생성 간격 (초)
    public float limitTime = 30; // 제한시간
    private bool isGameRunning = true; // 게임이 진행 중인지 여부
    private List<GameObject> activeMeats = new List<GameObject>(); // 활성화된 고기 오브젝트 리스트

    public GameObject gameOverPanel;
   
    void Start()
    {
        StartCoroutine(GameTimer());
        StartCoroutine(SpawnMeat());
    }
    IEnumerator GameTimer()
    {
        // 게임 지속 시간 동안 대기
        yield return new WaitForSeconds(limitTime);

        // 게임 종료
        isGameRunning = false;

        gameOverPanel.SetActive(true);

        Debug.Log("Game Over!");
    }

    IEnumerator SpawnMeat()
    {
        while (isGameRunning)
        {
            // 고기 오브젝트 생성
            Instantiate(meatPrefab, GetRandomStartPosition(), Quaternion.identity);
            Instantiate(meatPrefab, GetRandomStartPosition(), Quaternion.identity);

            // 다음 고기 생성까지 대기
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector2 GetRandomStartPosition()
    {
        // 랜덤한 시작 위치 설정 (좌측 또는 우측)
        float x = Random.Range(0, 2) == 0 ? -16f : 16f;
        float y = Random.Range(-5f, 5f); // Y좌표는 랜덤
        return new Vector2(x, y);
    }

}