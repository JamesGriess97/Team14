using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : MonoBehaviour {

	
	public Transform player;
	public Transform troll;
	private Vector3 target;
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
		target = troll.position - player.transform.position;
		float step = moveSpeed* Time.deltaTime;
		//Vector3 movement = new Vector3(Vector3.MoveTowards(troll.position, player.position, moveSpeed).x, 0, Vector3.MoveTowards(troll.position, player.position, moveSpeed).z);
		troll.position = Vector3.MoveTowards(troll.position, player.position, step);

		
		//Vector3 movement = new Vector3();
		//troll.GetComponent<CharacterController>().Move(movement * Time.deltaTime);	
	
		//if the player is close enough launch an attack
		if(target.magnitude < 3) {
			//anim.SetBool ("Attack", true);
		} 
		else{
			//anim.SetBool ("Attack", false);
		}
		
		
	}
}
