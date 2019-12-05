using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class canvasCode : MonoBehaviour
{
    MarbleMovement mm;
    public GameObject jump;
    public GameObject tele;
    public GameObject life;
    float time;
    TextMeshProUGUI timer;
    void Start(){
        time=PlayerPrefs.GetFloat("Timer");
        mm=GameObject.Find("Marble").GetComponent<MarbleMovement>();
        jump=GameObject.Find("Jump");
        tele=GameObject.Find("Teleport");
        life=GameObject.Find("ExtraLife");
        timer=GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        jump.SetActive(false);
        tele.SetActive(false);
        life.SetActive(false);
    }
    void Update(){
        time+=Time.deltaTime;
        timer.text=time.ToString("0.0");
        PlayerPrefs.SetFloat("Timer",time);
    }
    void FixedUpdate(){
        if(mm.jumpActive){
            jump.SetActive(true);
            tele.SetActive(false);
            life.SetActive(false);
        }else{
            jump.SetActive(false);
        }
        if(mm.teleActive){
            jump.SetActive(false);
            tele.SetActive(true);
            life.SetActive(false);
        }else{
            tele.SetActive(false);
        }
        if(mm.lifeActive){
            jump.SetActive(false);
            tele.SetActive(false);
            life.SetActive(true);
        }else{
            life.SetActive(false);
        }
    }
}
