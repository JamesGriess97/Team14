using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisionDetector : MonoBehaviour {

    private int health = 1;
	public int barrelExperienceValue = 5; 

    void OnTriggerEnter(Collider other) {
        health -= 1; 

        if (health == 0) {
			experienceManager.experience += barrelExperienceValue;
            Destroy(gameObject);
        }
    }
}
