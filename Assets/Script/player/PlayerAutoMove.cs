﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAutoMove : MonoBehaviour {

    private NavMeshAgent agent;
    public float minDistance = 3;

    public Transform target;

    void Start(){
        agent = this.GetComponent<NavMeshAgent>();
    }

    void Update(){
        if (agent.enabled) {
            if (agent.remainingDistance < minDistance && agent.remainingDistance!=0) {
                agent.isStopped = true;
                agent.enabled = false;
                TaskManager._instance.OnArriveDestination();
            }
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f) {
            StopAuto();//如果在寻路过程中按下移动控制键，那么就停止寻路
        }
        /*if (Input.GetMouseButtonDown(0)) {
            SetDestination(target.position);
        }*/
    }

    public void SetDestination(Vector3 targetPos){
        agent.enabled = true;
        agent.SetDestination(targetPos);
    }

    public void StopAuto(){
        if (agent.enabled) {
            agent.isStopped = true;
            agent.enabled = false;
        }
    }
}
