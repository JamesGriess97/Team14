using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisionDetector : MonoBehaviour {

    private int health = 3;
	public Slider healthSlider;
	public int barrelExperienceValue = 5; 



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        Debug.Log("Health = " + health);
        health -= 1; 

		healthSlider.value = health;
        if (health == 0) {
			experienceManager.experience += barrelExperienceValue;
            Destroy(gameObject);
        }
    }
}
