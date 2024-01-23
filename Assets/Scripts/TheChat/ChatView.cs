using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatView : MonoBehaviour
{
    public static ChatView instance;
    private void Awake(){
        instance = this;
    }

    public GameObject MessageView;
    public Transform Content;
    private bool isUser = false;
    public ScrollRect ChatScroll;

    public void UpdateScroll(){

        isUser = false;
        foreach (Transform child in Content)
        {
            Destroy(child.gameObject);
        }

       int ListLength = ReplayMessage.instance.TheChatList.Count;
       for (int i = 0; i < ListLength; i++) {
        GameObject currentMessage =  (GameObject)Instantiate(MessageView, transform.position, Quaternion.identity);
        currentMessage.GetComponent<TheMessage>().Build(isUser,ReplayMessage.instance.TheChatList[i]);
        currentMessage.transform.SetParent(Content);
        currentMessage.transform.localScale = new Vector3(1,1,1);
        if (!isUser){
            isUser = true;
        } else {
            isUser = false;
        }
       }

       ChatScroll.verticalNormalizedPosition = 0f;
    }
}
