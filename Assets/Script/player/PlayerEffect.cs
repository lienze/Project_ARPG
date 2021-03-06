﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour {

    private Renderer[] rendererArray;
    private NcCurveAnimation[] curveAnimArray;

	// Use this for initialization
	void Start () {
        rendererArray = this.GetComponentsInChildren<Renderer>();
        curveAnimArray = this.GetComponentsInChildren<NcCurveAnimation>();
	}

    void Update(){

    }

    public void Show(){
        foreach (Renderer renderer in rendererArray) {
            renderer.enabled = true;
        }

        foreach (NcCurveAnimation anim in curveAnimArray) {
            anim.ResetAnimation();
        }
    }
}
