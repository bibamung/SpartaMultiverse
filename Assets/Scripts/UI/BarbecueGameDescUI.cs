using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BarbecueGameDescUI : MonoBehaviour
{
    [SerializeField] private float minX = 39f; 
    [SerializeField] private float maxX = 42f; 
    [SerializeField] private float minY = -11f;  
    [SerializeField] private float maxY = -8f;

    public GameObject descPanel;

    public Transform target;

    private void Update()
    {
        Vector2 playerPosition = target.transform.position;

        bool isInAreaX = false;
        bool isInAreaY = false;

        isInAreaX = (playerPosition.x > minX && playerPosition.x < maxX) ? true : false;
        isInAreaY = (playerPosition.y > minY && playerPosition.y < maxY) ? true : false;

        if (isInAreaX && isInAreaY)
        {
            descPanel.SetActive(true);
        }
        else
        {
            descPanel.SetActive(false);
        }
    }
}
