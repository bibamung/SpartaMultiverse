using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    [SerializeField] private float minX = -0.4f; // ī�޶� �̵� �ּ� X
    [SerializeField] private float maxX = 12f;  // ī�޶� �̵� �ִ� X
    [SerializeField] private float minY = -1.0f;  // ī�޶� �̵� �ּ� Y
    [SerializeField] private float maxY = 0f;   // ī�޶� �̵� �ִ� Y

    float offsetX;
    float offsetY;

    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y + target.position.y;
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        pos.y = target.position.y + offsetY;
        transform.position = pos;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        // ���ο� ��ġ ���
        Vector3 newPosition = transform.position;
        newPosition.x = target.position.x + offsetX;
        newPosition.y = target.position.y + offsetY;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // ī�޶� ��ġ ������Ʈ
        transform.position = newPosition;

    }
}
