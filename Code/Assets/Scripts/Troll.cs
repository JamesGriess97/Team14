using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Troll : MonoBehaviour {
    public int health = 5;
	public Slider healthSlider;
	public Transform sliderT;
    public Transform player;
	public Transform troll;
	public float moveSpeed = .2f;
	public int trollExperienceValue = 10; 

	private float distance;
	float timer = 0f;
	float timerStart;

	Animator anim;
	AIProcessor brain;
	UnityEngine.AI.NavMeshAgent nav;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent>();
		anim = GetComponentInChildren<Animator>();
		timerStart = Time.time;
		brain = new AIProcessor();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(troll.position, player.position);
		sliderT.position = troll.position;
		timer = Time.time - timerStart;
		if(isAggressive()){
			if (distance > 30f) {
				// player too far away, idle
				idleTroll();
			} else if (distance < 30f && distance > 3f) {
				// player out of range, move towards player
				moveTroll();
			} else if(distance < 3f) {
				// player close, attack
				if(brain.shouldAttack()){
					attack();
				} else if((timer > 10f)&&(brain.inRange())) {
					attack();	
				} else {
					if(brain.shouldStepBack()) {
						stepBack();
					} else {
						moveTroll();
					}
				}
			}
		} else{
			moveTroll();
		}
    }

	void OnTriggerEnter(Collider other) {
		health -= 1; 
	
        if (health == 0) {
			experienceManager.experience += trollExperienceValue;
            Destroy(gameObject);
        }
		healthSlider.value = health;
    } 
	
	//controls troll movement procedures
	void moveTroll(){
		anim.SetBool("Attack",false);
		anim.SetBool("Walk",true);
		if(isAggressive()){
			// run towards the player
			nav.SetDestination(player.position);
		} else if(!isAggressive()) {
			// run away from the player
			anim.SetBool("Walk", true);
			moveSpeed = 0.4f;
			Vector3 newDestination = player.position * -1;
			nav.SetDestination(newDestination);
		} else {
			idleTroll();
		}
	}
	
	// sets troll to idle state
	void idleTroll(){
		Debug.Log("idle");
		anim.SetBool("Walk", false);
		anim.SetBool("Attack",false);
		nav.SetDestination(troll.position);
	}

	// initiates the troll attack animation
	void attack(){
		timerStart = Time.time;
		troll.LookAt(player);
		nav.SetDestination(troll.position);
		anim.SetBool("Walk", false);
		anim.SetBool("Attack",true);
	}
	
	// returns whether or not the troll should be aggressive or not
	public bool isAggressive(){
		if(health < 2){
			return false;
		} else {
			return true;
		}
	}
	
	void stepBack(){
		Vector3 newDestination;
		newDestination.x = troll.position.x - 5;
		newDestination.y = troll.position.y;
		newDestination.z = troll.position.z;
		nav.SetDestination(newDestination);
	}

}
