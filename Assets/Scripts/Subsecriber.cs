using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subsecriber : MonoBehaviour
{
    public static Subsecriber instance;
    private void Awake(){
        instance = this;
    }

    public GameObject[] Sub;

    void Start(){
        foreach (GameObject g in Sub){
            g.SetActive(false);
        }
        Sub[0].SetActive(true);
    }

    public void ChoseSub(int i){
        foreach (GameObject g in Sub){
            g.SetActive(false);
        }
        Sub[i].SetActive(true);
    }
}
