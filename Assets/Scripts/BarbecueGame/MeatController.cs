using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatController : MonoBehaviour
{
    public float speed = 15f; // �̵� �ӵ�
    public float height = 3f; // �������� �ִ� ����

    public Sprite[] meatSprites; // �������� ������ ��������Ʈ �迭

    private Vector2 startPos; // ���� ��ġ
    private Vector2 targetPos; // ��ǥ ��ġ
    private float startTime; // �̵� ���� �ð�
    private float journeyLength; // ��ü �̵� �Ÿ�

    private GameManager gameManager; // ���� �Ŵ��� ����
    private SpriteRenderer spriteRenderer; // ��������Ʈ ������

    //private int[] foodScore = { 2, 1, 2, 1, 3, 1, -3, 1, -1, 1 };

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        // ��������Ʈ ������ ������Ʈ ��������
        spriteRenderer = GetComponent<SpriteRenderer>();

        // ���� ��������Ʈ ����
        if (meatSprites.Length > 0)
        {
            int randomIndex = Random.Range(0, meatSprites.Length);
            spriteRenderer.sprite = meatSprites[randomIndex];
        }

        // ���� ��ġ�� ��ǥ ��ġ ����
        SetStartAndTargetPositions();
        startTime = Time.time;
        journeyLength = Vector2.Distance(startPos, targetPos);
    }

    void Update()
    {
        // �ð��� ���� �̵� ����� ��� (0 ~ 1)
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / journeyLength;

        // ������ � ����
        if (fractionOfJourney < 1f)
        {
            // X��ǥ�� ���� ����
            float x = Mathf.Lerp(startPos.x, targetPos.x, fractionOfJourney);
            // Y��ǥ�� ������ � (���� ���)
            float y = startPos.y + Mathf.Sin(fractionOfJourney * Mathf.PI) * height;
            transform.position = new Vector2(x, y);
        }
        else
        {
            // �̵��� ������ ���ο� ���� ��ġ�� ��ǥ ��ġ ����
            SetStartAndTargetPositions();
            startTime = Time.time;
            journeyLength = Vector2.Distance(startPos, targetPos);
        }
    }

    void SetStartAndTargetPositions()
    {
        // ���� ��ġ�� ��ǥ ��ġ�� �������� ����
        if (Random.Range(0, 2) == 0) // �������� ����
        {
            startPos = new Vector2(-16f, Random.Range(-5f, 5f));
            targetPos = new Vector2(16f, Random.Range(-5f, 5f));
        }
        else // �������� ����
        {
            startPos = new Vector2(16f, Random.Range(-5f, 5f));
            targetPos = new Vector2(-16f, Random.Range(-5f, 5f));
        }

        // ��� ������Ʈ�� ���� ��ġ ����
        transform.position = startPos;
    }

}
