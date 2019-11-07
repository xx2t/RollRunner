using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarbleMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 dir = Vector3.zero;
    Vector3 dirR = Vector3.zero;
    public bool debug = true;
    public int speed = 10;
    GameObject marb;
    Transform arrowIndicator;
    int index=1;
    
    void Start()
    {
        if(PlayerPrefs.GetInt("Index")>0){
            index=PlayerPrefs.GetInt("Index");
        }
        arrowIndicator=GameObject.Find("Arrow").transform;
        marb=GameObject.Find("Marb");
        rb=this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        dir.x=Input.acceleration.x;
        dir.z=Input.acceleration.y*2;
        dirR.z=Input.acceleration.y*2;
        dirR.x=Input.acceleration.x;
        if(debug){
            Debug.DrawRay(this.transform.position,dir,Color.red,1);
        }
        arrowIndicator.rotation=Quaternion.LookRotation(dir,Vector3.up);
        if(Input.GetKey(KeyCode.RightArrow)){
            dir.x=1;
            dirR.z=1;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            dir.x=-1;
            dirR.z=-1;
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            dir.z=1;
            dirR.x=1;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            dir.z=-1;
            dirR.x=-1;
        }
    }
    void FixedUpdate(){
        rb.AddForce(dir*speed);
        marb.transform.Rotate(dirR*speed);
    }
    void OnCollisionEnter(Collider other){
        rb.AddForce(-dir*speed*speed);
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("End")){
            Debug.Log("Level Over");
            SceneManager.LoadScene(index);
            index++;
            PlayerPrefs.SetInt("Index",index);
        }
    }
}
