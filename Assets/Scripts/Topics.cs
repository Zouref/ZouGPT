using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Topics : MonoBehaviour
{
    public static Topics instance;
    private void Awake(){
        instance = this;
    }

    public string[] SocialMedia;
    public string[] SocialMedia_Des;

    public string[] Education;
    public string[] Education_Des;

    public string[] IdeasBussniss;
    public string[] IdeasBussniss_Des;

    public string[] Health;
    public string[] Health_Des;

    public string[] Emotions;
    public string[] Emotions_Des;

    public string[] Nature;
    public string[] Nature_Des;

    public string[] Entertainment;
    public string[] Entertainment_Des;

    public TMP_Text TitleName;
    public Transform Content;
    public GameObject TopicPref;

    public void GetServices(string topic){
        
     TitleName.text = topic;

     if (Content.childCount > 0){
      foreach (Transform tr in Content){
        Destroy(tr.gameObject);
      }
     }

     for (int i = 0; i < 10; i++){
      GameObject GM = (GameObject)Instantiate(TopicPref, transform.position, Quaternion.identity);
      if (topic == "SocialMedia"){
       GM.GetComponent<TopicField>().Name = SocialMedia[i];
       GM.GetComponent<TopicField>().ShortDes = SocialMedia_Des[i];
      } else if (topic == "Education"){
       GM.GetComponent<TopicField>().Name = Education[i];
       GM.GetComponent<TopicField>().ShortDes = Education_Des[i];
      } else if (topic == "IdeasBussniss"){
       GM.GetComponent<TopicField>().Name = IdeasBussniss[i];
       GM.GetComponent<TopicField>().ShortDes = IdeasBussniss_Des[i];
      } else if (topic == "Health"){
       GM.GetComponent<TopicField>().Name = Health[i];
       GM.GetComponent<TopicField>().ShortDes = Health_Des[i];
      } else if (topic == "Emotions"){
       GM.GetComponent<TopicField>().Name = Emotions[i];
       GM.GetComponent<TopicField>().ShortDes = Emotions_Des[i];
      } else if (topic == "Nature"){
       GM.GetComponent<TopicField>().Name = Nature[i];
       GM.GetComponent<TopicField>().ShortDes = Nature_Des[i];
      } else if (topic == "Entertainment"){
       GM.GetComponent<TopicField>().Name = Entertainment[i];
       GM.GetComponent<TopicField>().ShortDes = Entertainment_Des[i];
      }
      GM.GetComponent<TopicField>().ValidField();
      GM.transform.SetParent(Content); 
     }
    }
}
