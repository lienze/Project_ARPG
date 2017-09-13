using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public Vector3 offset;

    private Transform playerBip;

    void Start(){
        playerBip = GameObject.FindGameObjectWithTag("Player").transform.Find("Bip01");
    }


    void Update(){
        transform.position = playerBip.position + offset;
    }
}
