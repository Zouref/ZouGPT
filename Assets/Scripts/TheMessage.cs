using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TheMessage : MonoBehaviour
{
    public GameObject UserBack, GptBack;
    public TMP_Text UserTxt, GPT_Txt;
    public RectTransform User_tr, GPT_tr;
    RectTransform rt;
    
    public void Build(bool isUser, string theMessage){
        rt = this.GetComponent<RectTransform>();

       if (isUser){
        UserBack.SetActive(true);
        UserTxt.text = theMessage;
        LayoutRebuilder.ForceRebuildLayoutImmediate(User_tr);
        rt.sizeDelta = new Vector2(1000, User_tr.sizeDelta.y);
       } else {
        GptBack.SetActive(true);
        GPT_Txt.text = theMessage;
        LayoutRebuilder.ForceRebuildLayoutImmediate(GPT_tr);
        rt.sizeDelta = new Vector2(1000, GPT_tr.sizeDelta.y);
       } 

       
    }
}
