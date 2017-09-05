using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVillageMove : MonoBehaviour {

    public float velcoity = 5;
    Rigidbody rigidBody;
    void Awake(){
        rigidBody = this.GetComponent<Rigidbody>();
    }

    void Update(){
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vel = rigidBody.velocity;
        rigidBody.velocity = new Vector3(-h*velcoity, vel.y, -v*velcoity);

        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f) {
            transform.rotation = Quaternion.LookRotation(new Vector3(-h, 0, -v));
        }
    }

}
