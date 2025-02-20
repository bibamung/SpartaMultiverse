using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int charPerSeconds;
    public GameObject endCursor;

    TMP_Text msgText;
    
    string targetMsg;
    int index;
    
    public void SetMsg(string msg)
    {
        Debug.Log(msg);
        targetMsg = msg;
        EffectStart();
    }
    void EffectStart()
    {
        if (msgText == null)
        {
            msgText = GetComponent<TMP_Text>();
        }
        msgText.text = "";
        index = 0;
        endCursor.SetActive(false);
        
        Invoke("Effecting", 1 / charPerSeconds);
    }
    void Effecting()
    {
        if(msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];
        index++;

        Invoke("Effecting", 1 / charPerSeconds);
    }
    void EffectEnd()
    {
        endCursor.SetActive(true);
    }

}
