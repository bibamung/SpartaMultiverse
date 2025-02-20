using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class B_PlayerController : MonoBehaviour
{
    public float moveSpeed = 15f; // 위로 이동 속도
    public float returnSpeed = 3f; // 원래 위치로 돌아오는 속도
    public float maxHeight = 1f; // Y좌표 최댓값
    private float originalY; // 플레이어의 원래 Y 위치
    private bool isMoving = false; // 플레이어가 이동 중인지 여부
    

    public B_GameUI gameUI;
    public MeatController meatController;

    public int score = 0;

    void Start()
    {
        // 플레이어의 원래 Y 위치 저장
        originalY = -14f;
    }

    void Update()
    {
        // 플레이어1 (W 키 입력)
        if (gameObject.name == "Player1" && Input.GetKey(KeyCode.W) && transform.position.y == originalY)
        {
            MoveUp();
        }
        // 플레이어2 (위쪽 방향키 입력)
        else if (gameObject.name == "Player2" && Input.GetKey(KeyCode.UpArrow) && transform.position.y == originalY)
        {
            MoveUp();
        }

        // 이동 중이 아니라면 원래 위치로 서서히 돌아옴
        if (!isMoving)
        {
            ReturnToOriginalPosition();
        }
    }

    void MoveUp()
    {
        // Y좌표가 최댓값을 넘지 않도록 제한
        if (transform.position.y < maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight + 0.5f, 0);
        }
        else
        {
            // 최댓값에 도달하면 이동 중지
            isMoving = false;
        }
    }

    void ReturnToOriginalPosition()
    {
        // 원래 위치로 서서히 돌아옴
        if (transform.position.y > originalY)
        {
            transform.Translate(Vector2.down * returnSpeed * (Time.deltaTime*8));
        }
        else
        {
            // 원래 위치에 도달하면 Y좌표 고정
            transform.position = new Vector2(transform.position.x, originalY);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meat"))
        {
            score ++;
            Destroy(collision.gameObject);
            gameUI.AddScore(gameObject.name, 1);
        }
    }

}
