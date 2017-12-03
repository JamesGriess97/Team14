using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float startingHealth = 100;
	public float currentHealth ;
	public Slider healthSlider;
	float timer;

	Animator anim;
	PlayerController playerMovement;
	bool isDead;
	bool damaged;


	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
		playerMovement = GetComponent<PlayerController> ();
		currentHealth = startingHealth;
	}
	// Update is called once per frame
	void Update () {
		//recover health, every second
		timer += Time.deltaTime;
		if(timer>= 1 && currentHealth > 0f && currentHealth < startingHealth){
			timer = 0f;
			currentHealth += 0.5f;
			healthSlider.value = currentHealth;
		}
	}

	void OnTriggerEnter(Collider other) {
		//if(!anim.GetCurrentAnimatorStateInfo(0).IsName("AttackPunch") && !anim.GetCurrentAnimatorStateInfo(0).IsName("AttackKick")) {
		Debug.Log("hit");
			damaged = true;
			currentHealth -= 10;
			healthSlider.value = currentHealth;
			if (currentHealth <= 0) {
				//Destroy (gameObject);
				anim.SetBool("GameOver", true);
			}
			
		//}
	}
}
