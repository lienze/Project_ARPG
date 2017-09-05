using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float velcoity = 5;
    Rigidbody rigidBody;
    void Awake(){
        rigidBody = this.GetComponent<Rigidbody>();
    }

    void Update(){
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vel = rigidBody.velocity;
        rigidBody.velocity = new Vector3(-h*velcoity, vel.y, v*velcoity);
    }

}
