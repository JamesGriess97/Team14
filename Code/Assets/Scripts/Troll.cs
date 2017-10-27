using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : MonoBehaviour {

	
	public GameObject player;
	public Transform troll;
	private Vector3 distance;
	Animator anim;
    public float gravity = 9.8f;
    private float vSpeed = 0f;
	public float moveSpeed = 1f;
    public float rotationSpeed = 5f;
	private float moveFB, moveLR;
	
	// Use this for initialization
	void Start () {
		moveFB = 0;
		moveLR = 0;
	    int trollHealth = 5;
	}
	
	// Update is called once per frame
	void Update () {
		distance = transform.position - player.transform.position;
		//move on a set path
		if(moveLR < 10){
			moveLR = moveLR++;
		}
		else{
			moveLR = moveLR--;
		}
		
		Vector3 movement = new Vector3(moveLR, 0, moveFB);
		troll.GetComponent<CharacterController>().Move(movement * Time.deltaTime);	
	
		//if the player is close enough launch an attack
		if(distance.magnitude < 3) {
			//anim.SetBool ("Attack", true);
		} 
		else{
			//anim.SetBool ("Attack", false);
		}
		
		
	}
}
