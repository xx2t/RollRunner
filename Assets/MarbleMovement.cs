using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

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
    Slider scoreLoad;
    MusicManager mm;
    int teleports;
    void Awake(){
        mm=GameObject.Find("MusicManager").GetComponent<MusicManager>();
        scoreLoad=GameObject.Find("ScoreLoad").GetComponent<Slider>();
        aud=this.GetComponent<AudioSource>();
        arrowIndicator=GameObject.Find("Arrow").transform;
        rb=this.GetComponent<Rigidbody>();
    }
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex==0){
            PlayerPrefs.SetFloat("calx",0);
            PlayerPrefs.SetFloat("calz",0);
            calibratedDir.x=0;
            calibratedDir.z=0;
            Calibrate();
        }else if(PlayerPrefs.GetFloat("calx")!=0||PlayerPrefs.GetFloat("calz")!=0){
            calibratedDir.x=PlayerPrefs.GetFloat("calx");
            calibratedDir.z=PlayerPrefs.GetFloat("calz");
        }
        currentScene=SceneManager.GetActiveScene().buildIndex;
        index=currentScene+1;
        scoreLoad.value=0;
        StartCoroutine(mm.StartNextLevel());
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
        scoreLoad.value=score;
        if(Input.GetKeyDown(KeyCode.P)&&teleports>0){
            Teleport();
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("End")){
            Debug.Log("Level Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            index=SceneManager.GetActiveScene().buildIndex+1;
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
    void Teleport(){
        Debug.Log("Teleporting dir = "+dir);
        Debug.Log("dir.magnitude = "+ dir.magnitude);
        this.transform.Translate(arrowIndicator.forward*3,Space.World);
    }
}
