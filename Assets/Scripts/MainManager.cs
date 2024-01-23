using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    private void Awake(){
        instance = this;
    }
    
    public GameObject MainPanel, ChatPanel, LoadingPanel;
    public GameObject UpgradePanel, ServicePanel, SettingsPanel;

    public void RateApp(){
        Application.OpenURL("http://www.Google.com");
    }

    public void BackToMain(){
      MainPanel.GetComponent<Animator>().Play("GetMain");
      StartCoroutine(EndChating());
    }

    private IEnumerator EndChating(){
        yield return new WaitForSeconds(1f);
        ReplayMessage.instance.EndChat();
    }

    public void ChatNow(){
     ReplayMessage.instance.StartReplaying();
     MainPanel.GetComponent<Animator>().Play("HideMain");
    }

    public void OpenUpgrade(){
     UpgradePanel.GetComponent<Animator>().Play("GetUpgrade");
    }

    public void CloseUpgrade(){
     UpgradePanel.GetComponent<Animator>().Play("HideUpgrade");
    }

    public void OpenServices(string s){
     Topics.instance.GetServices(s);
     ServicePanel.GetComponent<Animator>().Play("GetServices");
    }

    public void CloseServices(){
     ServicePanel.GetComponent<Animator>().Play("HideServices");
    }

    public void OpenSettings(){
     SettingsPanel.GetComponent<Animator>().Play("GetSettings");
    }

    public void CloseSettings(){
     SettingsPanel.GetComponent<Animator>().Play("HideSettings");
    }

}
