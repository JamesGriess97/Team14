using System.Collections;
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
		timer = Time.time - timerStart;
		if(isRetreat()){
			moveTroll();
		}
		else if(distance < 30f){
			if(brain.shouldAttack()){
				attack();
			}
			else if((timer > 5f)&&(brain.inRange())){
				attack();	
			}
			else{
				if(brain.shouldStepBack()){
					stepBack();
				}
				else{
					moveTroll();
				}
			}
		}
		else{
			idleTroll();
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
		anim.SetBool("Walk",true);
		if(aggressive){
		nav.SetDestination(player.position);
		}
		else if(!aggressive){
		anim.SetBool("Walk", true);
		moveSpeed = 0.4f;
		Vector3 newDestination;
		newDestination.x = player.position.x * -1;
		newDestination.y = player.position.y;
		newDestination.z = player.position.z * -1;
		
		nav.SetDestination(newDestination);
		}
		else{
			idleTroll();
		}
	}
	
	//force troll stand to stand still
	void idleTroll(){
		anim.SetBool("Walk", false);
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
	
	public bool isRetreat(){
		if(health < 2){
			aggressive = false;
			return true;
		}
		else{
			aggressive = true;
			return false;
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
