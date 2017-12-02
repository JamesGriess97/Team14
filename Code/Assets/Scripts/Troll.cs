﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Troll : MonoBehaviour {
    public int health = 5;
	public Slider healthSlider;
	PlayerHealth playerHealth;
    public Transform player;
	public Transform troll;
	private float distance;
	Animator anim;
    public float gravity = 9.8f;
    private float vSpeed = 0f;
	public float moveSpeed = .2f;
    public float rotationSpeed = 5f;
	UnityEngine.AI.NavMeshAgent nav;
	private float playerAttackTime = 0.5f;
	float timer =0f;
	float timerStart;
    private Vector3 posOrig;
	bool aggressive = true;
	bool distanceAttack;
	AIProcessor brain;

	public int trollExperienceValue = 10; 

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <UnityEngine.AI.NavMeshAgent>();
		anim = GetComponentInChildren<Animator>();
		timerStart = Time.time;
		aggressive = true;
		brain = new AIProcessor();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(troll.position, player.position);
		Debug.Log("distance: " + distance);
		Debug.Log("isAggressive: " + isAggressive());
		timer = Time.time - timerStart;
		if(isAggressive()){
			if (distance > 10f) {
				// player too far away, idle
				idleTroll();
			} else if (distance < 10f && distance > 5f) {
				Debug.Log("move");
				// player out of range, move towards player
				moveTroll();
			} else if(distance < 5f) {
				// player close, attack
				Debug.Log("Attack");
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
		} 
		else{
			moveTroll();
		}
    }

     void OnTriggerStay(Collider other) {
		
        Debug.Log("collision");
		if (Input.GetMouseButtonDown(0)&& timer >= playerAttackTime) {
			timer = 0f;
			health -= 1;
		} 
			
		healthSlider.value = health;
	
        
        if (health == 0) {
            Destroy(gameObject);
			experienceManager.experience += trollExperienceValue;
        }
    } 
	
	//controls troll movement procedures
	void moveTroll(){
		anim.SetBool("Attack",false);
		anim.SetBool("Walk",true);
		if(aggressive){
			nav.SetDestination(player.position);
		} else if(!aggressive) {
			anim.SetBool("Walk", true);
			moveSpeed = 0.4f;
			Vector3 newDestination = player.position * -1;
			nav.SetDestination(newDestination);
		} else {
			idleTroll();
		}
	}
	
	//force troll stand to stand still
	void idleTroll(){
		Debug.Log("idle");
		anim.SetBool("Walk", false);
		anim.SetBool("Attack",false);
		nav.SetDestination(troll.position);
	}
	//troll attack procedures
	void attack(){
		timerStart = Time.time;
		troll.LookAt(player);
		nav.SetDestination(troll.position);
		anim.SetBool("Walk", false);
		anim.SetBool("Attack",true);
	}
	
	public bool isAggressive(){
		if(health < 2){
			aggressive = false;
			return false;
		}
		else{
			aggressive = true;
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
