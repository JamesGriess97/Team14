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
	private Vector3 distance;
	Animator anim;
    public float gravity = 9.8f;
    private float vSpeed = 0f;
	public float moveSpeed = .2f;
    public float rotationSpeed = 5f;
	UnityEngine.AI.NavMeshAgent nav;
	private float playerAttackTime = 0.5f;
	float timer =0f;
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
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		moveTroll();


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
		nav.SetDestination (player.position);
		}
		else if(!aggressive){
		anim.SetBool("Walk", true);
		moveSpeed = 0.08f;
		}
		else{
			idleTroll();
		}
	}
	
	//force troll stand to stand still
	void idleTroll(){
		anim.SetBool("Walk", false);
	}
	//troll attack procedures
	void attack(){
		anim.SetBool("Walk", false);
	}
	
	public bool isRetreat(){
		aggressive = false;
		return aggressive;
	}

}
