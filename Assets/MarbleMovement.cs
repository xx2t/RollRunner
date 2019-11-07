using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarbleMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 dir = Vector3.zero;
    //Vector3 dirR = Vector3.zero;
    public bool debug = true;
    public int speed = 10;
    Vector3 calibratedDir;
    //GameObject marb;
    Transform arrowIndicator;
    int index=1;
    string currentScene;
    
    void Start()
    {
        currentScene=SceneManager.GetActiveScene().name;
        if(currentScene=="RollerLvl1"){
            index=1;
        }
        Calibrate();
        if(PlayerPrefs.GetInt("Index")>0){
            index=PlayerPrefs.GetInt("Index");
        }
        arrowIndicator=GameObject.Find("Arrow").transform;
        //marb=GameObject.Find("Marb");
        rb=this.GetComponent<Rigidbody>();
    }
    public void Calibrate(){
        calibratedDir.x=Input.acceleration.x;
        calibratedDir.z=Input.acceleration.y;
        Debug.Log("Calibrated Dir = "+calibratedDir);
    }
    void Update()
    {
        dir.x=Input.acceleration.x-calibratedDir.x;
        dir.z=Input.acceleration.y*2-calibratedDir.z;
        if(dir.x>2){
            dir.x=2;
        }
        if(dir.z>2){
            dir.z=2;
        }
        //dirR.z=Input.acceleration.y*2;
        //dirR.x=Input.acceleration.x;
        if(debug){
            Debug.DrawRay(this.transform.position,dir,Color.red,1);
        }
        arrowIndicator.rotation=Quaternion.LookRotation(dir,Vector3.up);
        if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D)){
            dir.x=1;
            //dirR.z=1;
        }
        if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)){
            dir.x=-1;
            //dirR.z=-1;
        }
        if(Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W)){
            dir.z=1;
            //dirR.x=1;
        }
        if(Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S)){
            dir.z=-1;
            //dirR.x=-1;
        }
        if(Input.GetKeyDown(KeyCode.E)){
            Calibrate();
        }
    }
    void FixedUpdate(){
        rb.AddForce(dir*speed);
        //marb.transform.Rotate(dirR*speed);
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
