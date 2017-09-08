using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerVillageMove : MonoBehaviour {

    public float velcoity = 5;
    Rigidbody rigidBody;
    private NavMeshAgent agent;


    void Awake(){
        rigidBody = this.GetComponent<Rigidbody>();

    }

    void Start(){
        agent = this.GetComponent<NavMeshAgent>();
    }

    void Update(){
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vel = rigidBody.velocity;

        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f) {
            rigidBody.velocity = new Vector3(-h*velcoity, vel.y, -v*velcoity);
            transform.rotation = Quaternion.LookRotation(new Vector3(-h, 0, -v));
        }
        if (agent.enabled) {
            transform.rotation = Quaternion.LookRotation(agent.velocity);
        }
    }

}
