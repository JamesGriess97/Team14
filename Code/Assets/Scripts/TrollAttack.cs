// //using System.Collections;
// //using System.Collections.Generic;
// using UnityEngine;

// public class TrollAttack : MonoBehaviour {
// 	public float timeBetweenAttacks = 0.5f;
// 	public float attackDamage = 3f;

// 	Animator anim;
// 	GameObject player;
// 	PlayerHealth playerHealth;
// 	bool playerInRange ;
// 	float timer;



// 	//new:
// 	public GameObject target;

// 	public int maxRange = 5;
// 	public int minRange = 0;
// 	private Vector3 targetTran;


// 	// Use this for initialization
// 	void Start () {
// 		player = GameObject.FindGameObjectWithTag ("Player");
// 		playerHealth = player.GetComponent<PlayerHealth>();

// 		target = GameObject.FindWithTag("Player");
// 		targetTran = target.transform.position;

	
// 	}

// 	// Update is called once per frame

// 	void Update () {
// 		timer += Time.deltaTime;
// 		if ((Vector3.Distance(transform.position, target.transform.position) < maxRange)
// 			&& (Vector3.Distance(transform.position, target.transform.position) > minRange)
// 			&& timer >= timeBetweenAttacks){

// 			transform.LookAt(targetTran);
// 			transform.Translate(Vector3.forward * Time.deltaTime);
// 			Attack ();
// 		}

// 	}

// 	void Attack(){
// 		timer = 0f;
// 		if(playerHealth.currentHealth > 0){
// 			playerHealth.TakeDamage(attackDamage);
// 		}
// 	}
// }
