using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerVillageAnimation : MonoBehaviour {

    private Animator anim;
    private Rigidbody rigidBody;
    private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        rigidBody = this.GetComponent<Rigidbody>();
        agent = this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rigidBody.velocity.magnitude > 0.5f) {
            anim.SetBool("Move", true);
        } else {
            anim.SetBool("Move", false);
        }
        if (agent.enabled) {
            anim.SetBool("Move", true);
        }
	}
}
