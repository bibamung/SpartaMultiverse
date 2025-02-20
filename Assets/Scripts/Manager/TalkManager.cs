using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<string/*������Ʈ �̸�*/, string[]> talkData;
    Dictionary<string/*������Ʈ �̸�*/, Sprite> imageData;

    public Sprite npcsprite;

    void Awake()
    {
        talkData = new Dictionary<string , string[]>();
        imageData = new Dictionary<string , Sprite>();
        GenerateData();
    }

    public void GenerateData()
    {
        talkData.Add("Cow", new string[] { "����...(�ȳ�...)", "(���� ���ʿ� �ִ� ������ ���� �̴ϰ����� �� �� �־�)���Ӥä�", "(�Ʒ� ������� ���� �� �ٸ� ���ӵ� �־�)����!!" });
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
