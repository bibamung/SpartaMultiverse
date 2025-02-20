using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatController : MonoBehaviour
{
    public float speed = 15f; // 이동 속도
    public float height = 3f; // 포물선의 최대 높이

    public Sprite[] meatSprites; // 랜덤으로 적용할 스프라이트 배열

    private Vector2 startPos; // 시작 위치
    private Vector2 targetPos; // 목표 위치
    private float startTime; // 이동 시작 시간
    private float journeyLength; // 전체 이동 거리

    private GameManager gameManager; // 게임 매니저 참조
    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러

    //private int[] foodScore = { 2, 1, 2, 1, 3, 1, -3, 1, -1, 1 };

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        // 스프라이트 렌더러 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 랜덤 스프라이트 적용
        if (meatSprites.Length > 0)
        {
            int randomIndex = Random.Range(0, meatSprites.Length);
            spriteRenderer.sprite = meatSprites[randomIndex];
        }

        // 시작 위치와 목표 위치 설정
        SetStartAndTargetPositions();
        startTime = Time.time;
        journeyLength = Vector2.Distance(startPos, targetPos);
    }

    void Update()
    {
        // 시간에 따른 이동 진행률 계산 (0 ~ 1)
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / journeyLength;

        // 포물선 운동 적용
        if (fractionOfJourney < 1f)
        {
            // X좌표는 선형 보간
            float x = Mathf.Lerp(startPos.x, targetPos.x, fractionOfJourney);
            // Y좌표는 포물선 운동 (높이 계산)
            float y = startPos.y + Mathf.Sin(fractionOfJourney * Mathf.PI) * height;
            transform.position = new Vector2(x, y);
        }
        else
        {
            // 이동이 끝나면 새로운 시작 위치와 목표 위치 설정
            SetStartAndTargetPositions();
            startTime = Time.time;
            journeyLength = Vector2.Distance(startPos, targetPos);
        }
    }

    void SetStartAndTargetPositions()
    {
        // 시작 위치와 목표 위치를 랜덤으로 설정
        if (Random.Range(0, 2) == 0) // 좌측에서 시작
        {
            startPos = new Vector2(-16f, Random.Range(-5f, 5f));
            targetPos = new Vector2(16f, Random.Range(-5f, 5f));
        }
        else // 우측에서 시작
        {
            startPos = new Vector2(16f, Random.Range(-5f, 5f));
            targetPos = new Vector2(-16f, Random.Range(-5f, 5f));
        }

        // 고기 오브젝트의 시작 위치 설정
        transform.position = startPos;
    }

}
