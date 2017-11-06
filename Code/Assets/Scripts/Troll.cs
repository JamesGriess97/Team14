using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Troll : MonoBehaviour {
    public int health = 5;
	public Slider healthSlider;


    public Transform player;
	public Transform troll;

	private Vector3 distance;
	Animator anim;
    public float gravity = 9.8f;
    private float vSpeed = 0f;
	public float moveSpeed = 1f;
    public float rotationSpeed = 5f;
	private float moveFB, moveLR;
    private bool foo = false;

	private float playerAttackTime = 0.5f;
	float timer =0f;
    private Vector3 posOrig;
	// Use this for initialization
	void Start () {
		moveFB = 0;
		moveLR = 0;
	    //int trollHealth = 5;
        posOrig = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		timer += Time.deltaTime;
		Vector3 movement = new Vector3(transform.position.x * moveSpeed, 0, transform.position.y * moveSpeed);
        if(Vector3.Distance(transform.position, posOrig) > 20 && !foo) {
            moveSpeed = moveSpeed * -1;
            foo = true;
        } else if (Vector3.Distance(transform.position, posOrig) < 5 && foo) {
            moveSpeed = moveSpeed * -1;
            foo = false;
        }

        //Debug.Log("distance: " + Vector3.Distance(transform.position, posOrig));


        troll.GetComponent<CharacterController>().Move(movement * Time.deltaTime);



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
        }
    }

}
