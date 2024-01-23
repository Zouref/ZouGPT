using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoader : MonoBehaviour
{
    void Start(){
     Screen.fullScreen = false;
     StartCoroutine(LoadChat());
    }

    private IEnumerator LoadChat(){
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("TheChat");
    }
}
