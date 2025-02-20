using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public TalkManager talkManager;

    //public TextMeshProUGUI talkText;
    public TypeEffect talk;

    public GameObject scanObject;
    public GameObject dialogPanel;
    public Image npcImage;
    public int talkIndex;

    public bool isAction;

    private void Awake()
    {
        isAction = false;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Action(GameObject scanObj)
    {
        //isAction = true;            
        scanObject = scanObj;

        Talk(scanObject.name);
        
        dialogPanel.SetActive(isAction);
    }


    void Talk(string name)
    {
        string talkData = talkManager.GetTalk(name, talkIndex);

        npcImage.color = new Color(1,1,1,1);
        npcImage.sprite = talkManager.GetSprite(name);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }
        talk.SetMsg(talkData);
        //talkText.text = talkData;
        isAction = true;
        talkIndex++;
    }
}
