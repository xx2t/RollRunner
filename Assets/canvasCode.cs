using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasCode : MonoBehaviour
{
    MarbleMovement mm;
    public GameObject jump;
    public GameObject tele;
    public GameObject life;
    void Start(){
        mm=GameObject.Find("Marble").GetComponent<MarbleMovement>();
        jump=GameObject.Find("Jump");
        tele=GameObject.Find("Teleport");
        life=GameObject.Find("ExtraLife");
        jump.SetActive(false);
        tele.SetActive(false);
        life.SetActive(false);
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
