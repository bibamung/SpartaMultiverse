using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class B_PlayerController : MonoBehaviour
{
    public float moveSpeed = 15f; // ���� �̵� �ӵ�
    public float returnSpeed = 3f; // ���� ��ġ�� ���ƿ��� �ӵ�
    public float maxHeight = 1f; // Y��ǥ �ִ�
    private float originalY; // �÷��̾��� ���� Y ��ġ
    private bool isMoving = false; // �÷��̾ �̵� ������ ����
    

    public B_GameUI gameUI;
    public MeatController meatController;

    public int score = 0;

    void Start()
    {
        // �÷��̾��� ���� Y ��ġ ����
        originalY = -14f;
    }

    void Update()
    {
        // �÷��̾�1 (W Ű �Է�)
        if (gameObject.name == "Player1" && Input.GetKey(KeyCode.W) && transform.position.y == originalY)
        {
            MoveUp();
        }
        // �÷��̾�2 (���� ����Ű �Է�)
        else if (gameObject.name == "Player2" && Input.GetKey(KeyCode.UpArrow) && transform.position.y == originalY)
        {
            MoveUp();
        }

        // �̵� ���� �ƴ϶�� ���� ��ġ�� ������ ���ƿ�
        if (!isMoving)
        {
            ReturnToOriginalPosition();
        }
    }

    void MoveUp()
    {
        // Y��ǥ�� �ִ��� ���� �ʵ��� ����
        if (transform.position.y < maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight + 0.5f, 0);
        }
        else
        {
            // �ִ񰪿� �����ϸ� �̵� ����
            isMoving = false;
        }
    }

    void ReturnToOriginalPosition()
    {
        // ���� ��ġ�� ������ ���ƿ�
        if (transform.position.y > originalY)
        {
            transform.Translate(Vector2.down * returnSpeed * (Time.deltaTime*8));
        }
        else
        {
            // ���� ��ġ�� �����ϸ� Y��ǥ ����
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
