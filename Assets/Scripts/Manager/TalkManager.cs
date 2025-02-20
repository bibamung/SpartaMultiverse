using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<string/*오브젝트 이름*/, string[]> talkData;
    Dictionary<string/*오브젝트 이름*/, Sprite> imageData;

    public Sprite npcsprite;

    void Awake()
    {
        talkData = new Dictionary<string , string[]>();
        imageData = new Dictionary<string , Sprite>();
        GenerateData();
    }

    public void GenerateData()
    {
        talkData.Add("Cow", new string[] { "음머...(안녕...)", "(저기 왼쪽에 있는 닭한테 가면 미니게임을 할 수 있어)음머ㅓㅓ"," 미니게임도 준비되있으니까 잘 찾아봐" });
        imageData.Add("Cow", npcsprite);
    }

    public string GetTalk(string name, int talkIndex)
    {
        if (talkIndex == talkData[name].Length)
            return null;
        else
            return talkData[name][talkIndex];
    }

    public Sprite GetSprite(string name)
    {
        return imageData[name];
    }
}
