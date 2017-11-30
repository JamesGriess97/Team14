using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collisionDetector : MonoBehaviour {

    private int health = 3;
	public Slider healthSlider;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other) {
        //Debug.Log("Health = " + health);
		if (Input.GetMouseButtonDown(0)) {
			health -= 1;
		} 

		healthSlider.value = health;
        if (health == 0) {
            Destroy(gameObject);
        }
    }
}
