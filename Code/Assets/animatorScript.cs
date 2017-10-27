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
		if (Input.GetMouseButtonDown(0)) {
			anim.SetBool ("Attack2", true);
			Debug.Log ("clicked!");
		} 
		if (Input.GetMouseButtonUp(0)) {
			anim.SetBool ("Attack2", false);
		}
	}
}
