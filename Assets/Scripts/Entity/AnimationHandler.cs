using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    //string 값을 Hash라는 특정한 수로 바꿔줌 (StringToHash)
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
        if (direction == lastDirection) return; // 동일한 방향이면 변경하지 않음

        // 기존 방향 리셋
        animator.SetBool(IsForward, false);
        animator.SetBool(IsBack, false);
        animator.SetBool(IsLeft, false);
        animator.SetBool(IsRight, false);

        // 새로운 방향 설정
        if (direction.y > 0) // 위쪽
        {
            animator.SetBool(IsBack, true);
        }
        else if (direction.y < 0) // 아래쪽
        {
            animator.SetBool(IsForward, true);
        }
        else if (direction.x > 0) // 오른쪽
        {
            animator.SetBool(IsRight, true);
        }
        else if (direction.x < 0) // 왼쪽
        {
            animator.SetBool(IsLeft, true);
        }

        lastDirection = direction; // 마지막 방향 업데이트
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
