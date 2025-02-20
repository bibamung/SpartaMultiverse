using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeepCarInteraction : MonoBehaviour, IInteractable
{
    private PlayerController currentPlayer = null;  // ���� ž����
    private Rigidbody2D rb; // ���� Rigidbody
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
            audioSource.loop = true;  // �ݺ� ���
            audioSource.clip = engineSound;
            audioSource.playOnAwake = false; // ���� �� �ڵ� ��� X
        }
    }

    private void FixedUpdate()
    {
        if (currentPlayer != null) //�÷��̾ ž�� ���̸� Jeep�� ���� ������
        {
            rb.velocity = currentPlayer.MovementDirection * 10f; // �ӵ� ���� ����
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
        if (currentPlayer == null) //������ ����ִٸ� �÷��̾� ž��
        {
            player.isInsideJeep = true;
            player.SetSprite(null); // �÷��̾� ��������Ʈ�� ����
            player.moveSpeedMultiplier = 2f; // �÷��̾� ��ü �ӵ� ������� (���� ������ �̵�)
            player.transform.position = transform.position; // �÷��̾� ��ġ�� ������ �����ϰ� ����

            PlaySound(enterSound);
            StartEngineSound();

            currentPlayer = player;
        }
        else if (currentPlayer == player) //���� ž���ڰ� �ٽ� ��ȣ�ۿ��ϸ� ����
        {
            player.isInsideJeep = false;
            player.RestoreSprite(); // ���� ��������Ʈ�� ����
            player.moveSpeedMultiplier = 1f; // �ӵ� �������
            player.transform.position += new Vector3(1f, 0, 0); // ���� ������ ������

            PlaySound(exitSound);
            StopEngineSound();

            rb.velocity = Vector2.zero; //Jeep ����
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
            audioSource.Play(1); // ���� �Ҹ� ����
        }
    }

    private void StopEngineSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop(); // ���� �Ҹ� ����
        }
    }

    public void Interact()
    {
        //
    }
}
