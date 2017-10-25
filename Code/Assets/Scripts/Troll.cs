using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : MonoBehaviour {
	
	public GameObject player;
	
	private Vector3 distance;
	

	// Use this for initialization
	void Start () {
		distance = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//if the player is close enough, attack else move towards the player
		
		if(distance < 3){
			
		}
		else{
			transform.position -= transform.position;
		}
		
	}
}
