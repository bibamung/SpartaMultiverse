using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    //string ���� Hash��� Ư���� ���� �ٲ��� (StringToHash)
    private static readonly int IsForward = Animator.StringToHash("IsForward");
    private static readonly int IsLeft = Animator.StringToHash("IsLeft");
    private static readonly int IsBack = Animator.StringToHash("IsBack");
    private static readonly int IsRight = Animator.StringToHash("IsRight");
    

    protected Animator animator;
    private Vector2 lastDirection = Vector2.zero;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void UpdateDirection(Vector2 direction)
    {
        if (direction == lastDirection) return; // ������ �����̸� �������� ����

        // ���� ���� ����
        animator.SetBool(IsForward, false);
        animator.SetBool(IsBack, false);
        animator.SetBool(IsLeft, false);
        animator.SetBool(IsRight, false);

        // ���ο� ���� ����
        if (direction.y > 0) // ����
        {
            animator.SetBool(IsBack, true);
        }
        else if (direction.y < 0) // �Ʒ���
        {
            animator.SetBool(IsForward, true);
        }
        else if (direction.x > 0) // ������
        {
            animator.SetBool(IsRight, true);
        }
        else if (direction.x < 0) // ����
        {
            animator.SetBool(IsLeft, true);
        }

        lastDirection = direction; // ������ ���� ������Ʈ
    }


    /*
        public void Damage()
        {
            animator.SetBool(IsDamage, true);
        }

        public void InvincibilityEnd()
        {
            animator.SetBool(IsDamage, false);
        }*/
}
