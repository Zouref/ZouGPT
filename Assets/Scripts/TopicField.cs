using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopicField : MonoBehaviour
{
    public TMP_Text Name_tx, ShortDes_tx;
    [HideInInspector] public string Name ,StartMessage, ShortDes;
    [HideInInspector] public bool isQuestion = false;

    public void ValidField(){
        Name_tx.text = Name;
        ShortDes_tx.text = ShortDes;
    }

    public void Clicked(){
        MainManager.instance.CloseServices();
        MainManager.instance.ChatNow();
    }

}
