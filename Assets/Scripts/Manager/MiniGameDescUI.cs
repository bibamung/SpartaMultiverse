using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MiniGameDescUI : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage rawImage;

    [SerializeField] private float minX = 13f; // 카메라 이동 최소 X
    [SerializeField] private float maxX = 16.7f;  // 카메라 이동 최대 X
    [SerializeField] private float minY = 1f;  // 카메라 이동 최소 Y
    [SerializeField] private float maxY = 3f;   // 카메라 이동 최대 Y

    public GameObject descPanel; // UI 패널

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

        // Video Player 설정
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;

        // Render Texture 생성 및 할당
        RenderTexture renderTexture = new RenderTexture(1920, 1080, 32);
        videoPlayer.targetTexture = renderTexture;
        rawImage.texture = renderTexture;

        if (isInAreaX && isInAreaY)
        {
            descPanel.SetActive(true);
            // 비디오 재생
            videoPlayer.Play();

        }
        else
        {
            descPanel.SetActive(false);
            videoPlayer.Stop();
        }
    }



}
