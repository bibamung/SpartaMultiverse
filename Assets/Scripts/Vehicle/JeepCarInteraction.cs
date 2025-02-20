using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeepCarInteraction : MonoBehaviour, IInteractable
{
    private PlayerController currentPlayer = null;  // 현재 탑승자
    private Rigidbody2D rb; // 차량 Rigidbody
    Vector2 movementDirection;

    protected AnimationHandler animationHandler;

    private AudioSource audioSource;

    public AudioClip enterSound;
    public AudioClip exitSound;
    public AudioClip engineSound;

    float h, v;
    bool isHorizonMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animationHandler = GetComponent<AnimationHandler>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.loop = true;  // 반복 재생
            audioSource.clip = engineSound;
            audioSource.playOnAwake = false; // 시작 시 자동 재생 X
        }
    }

    private void FixedUpdate()
    {
        if (currentPlayer != null) //플레이어가 탑승 중이면 Jeep도 같이 움직임
        {
            rb.velocity = currentPlayer.MovementDirection * 10f; // 속도 조절 가능
        }
    }


    void Update()
    {
        if (currentPlayer != null)
        {
            float horizontal = GameManager.instance.isAction ? 0f : Input.GetAxisRaw("Horizontal");
            float vertial = GameManager.instance.isAction ? 0f : Input.GetAxisRaw("Vertical");
            movementDirection = new Vector2(horizontal, vertial).normalized;
            animationHandler.UpdateDirection(movementDirection);
        }
    }

    public void Interact(PlayerController player)
    {
        if (currentPlayer == null) //차량이 비어있다면 플레이어 탑승
        {
            player.isInsideJeep = true;
            player.SetSprite(null); // 플레이어 스프라이트를 숨김
            player.moveSpeedMultiplier = 2f; // 플레이어 자체 속도 원래대로 (이제 차량이 이동)
            player.transform.position = transform.position; // 플레이어 위치를 차량과 동일하게 설정

            PlaySound(enterSound);
            StartEngineSound();

            currentPlayer = player;
        }
        else if (currentPlayer == player) //현재 탑승자가 다시 상호작용하면 하차
        {
            player.isInsideJeep = false;
            player.RestoreSprite(); // 원래 스프라이트로 복귀
            player.moveSpeedMultiplier = 1f; // 속도 원래대로
            player.transform.position += new Vector3(1f, 0, 0); // 차량 옆으로 내리기

            PlaySound(exitSound);
            StopEngineSound();

            rb.velocity = Vector2.zero; //Jeep 정지
            currentPlayer = null;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            StopEngineSound();
            audioSource.PlayOneShot(clip, 0.3f);
        }
    }

    private void StartEngineSound()
    {
        if (audioSource != null && engineSound != null)
        {
            audioSource.clip = engineSound;
            audioSource.Play(1); // 엔진 소리 시작
        }
    }

    private void StopEngineSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop(); // 엔진 소리 정지
        }
    }

    public void Interact()
    {
        //
    }
}
