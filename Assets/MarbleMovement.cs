using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 dir = Vector3.zero;
    public bool debug = true;
    public int speed = 10;
    GameObject marb;
    void Start()
    {
        marb=GameObject.Find("Marb");
        rb=this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        dir.x=Input.acceleration.x;
        dir.z=Input.acceleration.y;
        if(debug){
            Debug.DrawRay(this.transform.position,dir,Color.red,1);
        }
    }
    void FixedUpdate(){
        rb.AddForce(dir*speed);
        marb.transform.Rotate(dir);
    }
}
