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
    public int jumpSpeed = 50;
    Vector3 calibratedDir;
    Transform arrowIndicator;
    int index=1;
    int currentScene;
    bool isGrounded;
    int score;
    AudioSource aud;
    public AudioClip coin;
    void Start()
    {
        aud=this.GetComponent<AudioSource>();
        currentScene=SceneManager.GetActiveScene().buildIndex;
        index=currentScene+1;
        Calibrate();
        arrowIndicator=GameObject.Find("Arrow").transform;
        rb=this.GetComponent<Rigidbody>();
    }
    public void Calibrate(){
        calibratedDir.x=Input.acceleration.x;
        calibratedDir.z=Input.acceleration.y;
        Debug.Log("Calibrated Dir = "+calibratedDir);
    }
    void Update()
    {
        if(Input.anyKey){
            dir.x=Input.GetAxis("Horizontal")-calibratedDir.x;
            dir.z=Input.GetAxis("Vertical")*2-calibratedDir.z;
        }else{
            dir.x=Input.acceleration.x-calibratedDir.x;
            dir.z=Input.acceleration.y*2-calibratedDir.z;
        }
        if(dir.x>1){
            dir.x=1;
        }
        if(dir.x<-1){
            dir.x=-1;
        }
        if(dir.z>1){
            dir.z=1;
        }
        if(dir.z<-1){
            dir.z=-1;
        }
        if(debug){
            Debug.DrawRay(this.transform.position,dir,Color.red,1);
        }
        arrowIndicator.rotation=Quaternion.LookRotation(dir,Vector3.up);
        if(Input.GetKeyDown(KeyCode.E)){
            Calibrate();
        }
        if(Input.touchCount>0&&isGrounded){
            Touch touch;
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                Jump();
            }
        }else if(Input.GetKeyDown(KeyCode.Space)&&isGrounded){
            Jump();
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("End")){
            Debug.Log("Level Over");
            SceneManager.LoadScene(index);
            index++;
            PlayerPrefs.SetInt("Index",index);
        }
        if(other.CompareTag("Spikes")){
            Debug.Log("Hit Spikes");
            SceneManager.LoadScene(currentScene);
        }
        if(other.CompareTag("Coin")){
            score++;
            Destroy(other.gameObject);
            aud.PlayOneShot(coin);
        }
    }
    void FixedUpdate(){
        rb.AddForce(dir*speed);
    }
    void OnCollisionEnter(){
        isGrounded=true;
    }
    void OnCollisionStay(){
        isGrounded=true;
    }
    void OnCollisionExit(){
        isGrounded=false;
    }
    void Jump(){
        rb.AddForce(Vector3.up*jumpSpeed,ForceMode.Impulse);
    }
    
}
