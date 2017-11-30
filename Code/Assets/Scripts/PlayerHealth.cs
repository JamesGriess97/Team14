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
		anim = GetComponent<Animator> ();
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

	public void TakeDamage(float amount){
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if (currentHealth <= 0 && !isDead) {
			//Destroy (gameObject);
			//anim.SetTrigger ("GameOver");
		}
	}
}
