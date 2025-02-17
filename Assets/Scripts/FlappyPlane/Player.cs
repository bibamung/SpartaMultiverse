using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;

    MiniGameManager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = MiniGameManager.Instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator != null)
            Debug.LogError("Not Founded Animator");

        if (_rigidbody != null)
            Debug.LogError("Not Founded Rigidbody");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0f)
            {
                //게임 재시작
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gamemanager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        //비행기 점프
        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y = flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        //각도 회전 
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    //충돌 처리함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        //die 애니메이션 실행하기 위한 조건 설정
        animator.SetInteger("isDie", 1);
        gamemanager.GameOver();
    }
}
