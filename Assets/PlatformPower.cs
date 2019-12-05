using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPower : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            other.transform.SetParent(this.transform);
        }
    }
    void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            other.transform.SetParent(null);
        }
    }
}
