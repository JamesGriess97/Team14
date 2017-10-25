using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public CapsuleCollider playerCollider;
	public float moveSpeed = 40;
	private GameObject troll;
	private Troll trollScript;
	// Use this for initialization
	void Start () {
//		troll = GameObject.Find ("Troll1");
//		trollScript = troll.GetComponent<Troll> ();
	}//end Start
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0f, moveVertical);
		transform.Translate (movement * Time.deltaTime * moveSpeed);
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			trollScript.trollHealth--;
//		}

	}//end Update



	void OnCollisionStay(Collision attack){
		if (attack.gameObject.tag == "Troll") {
			trollScript = attack.gameObject.GetComponent<Troll> ();
					if (Input.GetKeyDown (KeyCode.Space)&& trollScript.trollHealth >0) {
						trollScript.trollHealth--;
					}

			
		}
	}//end  OnCollsisionEnter




}//end class

