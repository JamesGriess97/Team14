﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorScript : MonoBehaviour {
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
        // attack animation
        if (Input.GetMouseButtonDown(0) || Input.GetButton("X360_Trigger")) {
			anim.SetBool ("Attack", true);
			//Debug.Log ("clicked!");
		} 
		if (Input.GetMouseButtonUp(0)) {
			anim.SetBool ("Attack", false);
		}

		// walk animation
		if ((Input.GetAxis ("Vertical") != 0) || (Input.GetAxis ("Horizontal") != 0)) {
			anim.SetFloat ("Speed", 2);
		} else {
			anim.SetFloat ("Speed", 0);
		}
	}
}
