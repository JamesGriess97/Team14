using System.Collections;
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
        if (Input.GetMouseButtonDown(0) || Input.GetButton("X360_B")) {
			anim.SetBool ("Attack", true);
			//Debug.Log ("clicked!");
		} 
		if (Input.GetMouseButtonUp(0)  || Input.GetButtonUp("X360_B")){
			anim.SetBool ("Attack", false);
		}

        float vert = Mathf.Abs(Input.GetAxis("Vertical"));
        float horiz = Mathf.Abs(Input.GetAxis("Horizontal"));

		// walk animation
		if ((vert != 0) || (horiz != 0)) {
			anim.SetFloat ("Speed", (vert + horiz) / 2f);
		} else {
			anim.SetFloat ("Speed", 0);
		}
	}
}
