using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float velocity = 5;

    private Rigidbody rigidBody;

    void Awake(){
        rigidBody = this.GetComponent<Rigidbody>();
    }

    void Update(){
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 nowVel = rigidBody.velocity;

        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f) {
            rigidBody.velocity = new Vector3(velocity * h, nowVel.y, v * velocity);

        } else {
            rigidBody.velocity = new Vector3(0, nowVel.y, 0);

        }
    }
}
