using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : MonoBehaviour {
<<<<<<< HEAD
	
	public GameObject player;
	
	private Vector3 distance;
	

	// Use this for initialization
	void Start () {
		distance = transform.position - player.transform.position;
=======
	public int trollHealth = 5;
	// Use this for initialization
	void Start () {
		
>>>>>>> 0b03b1793d29f4177df2bdd40d66e9c177bc0d2a
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		//if the player is close enough, attack else move towards the player
		
		if(distance < 3){
			
		}
		else{
			transform.position -= transform.position;
		}
=======
>>>>>>> 0b03b1793d29f4177df2bdd40d66e9c177bc0d2a
		
	}
}
