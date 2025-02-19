using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MiniGameDescUI : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage rawImage;

    [SerializeField] private float minX = 13f; // ī�޶� �̵� �ּ� X
    [SerializeField] private float maxX = 16.7f;  // ī�޶� �̵� �ִ� X
    [SerializeField] private float minY = 1f;  // ī�޶� �̵� �ּ� Y
    [SerializeField] private float maxY = 3f;   // ī�޶� �̵� �ִ� Y

    public GameObject descPanel; // UI �г�

    public Transform target;

    void Start()
    {
    }
    private void Update()
    {
        Vector2 playerPosition = target.transform.position;

        bool isInAreaX = false;
        bool isInAreaY = false;

        isInAreaX = (playerPosition.x > minX && playerPosition.x < maxX) ? true : false;
        isInAreaY = (playerPosition.y > minY && playerPosition.y < maxY) ? true : false;

        // Video Player ����
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;

        // Render Texture ���� �� �Ҵ�
        RenderTexture renderTexture = new RenderTexture(1920, 1080, 32);
        videoPlayer.targetTexture = renderTexture;
        rawImage.texture = renderTexture;

        if (isInAreaX && isInAreaY)
        {
            descPanel.SetActive(true);
            // ���� ���
            videoPlayer.Play();

        }
        else
        {
            descPanel.SetActive(false);
            videoPlayer.Stop();
        }
    }



}
