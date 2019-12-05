using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    Renderer rend;
    public GameObject jump;
    public GameObject tele;
    public GameObject life;
    void Start(){
        rend=this.GetComponent<Renderer>();
        jump=GameObject.Find("Jump");
        tele=GameObject.Find("Teleport");
        life=GameObject.Find("ExtraLife");
        jump.SetActive(false);
        tele.SetActive(false);
        life.SetActive(false);
    }
    void Update(){
        if(Input.anyKeyDown){
            rend.material.color=Random.ColorHSV();
        }
    }
}
