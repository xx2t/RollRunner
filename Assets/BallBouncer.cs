using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncer : MonoBehaviour
{
    // Start is called before the first frame update
    int forceSpeed = 20;
    public bool destroyAfterUse=false;
    void OnTriggerEnter(Collider other){
        if(other.gameObject.GetComponent<Rigidbody>()!=null){
            other.gameObject.GetComponent<Rigidbody>().AddForce(this.transform.up*forceSpeed, ForceMode.Impulse);
        }
        if(destroyAfterUse){
            this.gameObject.SetActive(false);
            StartCoroutine("Rebuild");
        }
    }
    IEnumerator Rebuild(){
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(true);
    }
}
