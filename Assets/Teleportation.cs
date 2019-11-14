using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform destination;
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            other.transform.position = destination.position;
        }
    }
}
