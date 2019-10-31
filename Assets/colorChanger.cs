using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    Renderer rend;
    void Start(){
        rend=this.GetComponent<Renderer>();
    }
    void Update(){
        if(input.anyKeyDown){
            rend.material.color=Random.ColorHSV();
        }
    }
}
