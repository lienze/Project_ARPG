using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranscriptManager : MonoBehaviour {

    public static TranscriptManager _instance;

    public GameObject player;

    void Awake(){
        _instance = this;
    }

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
