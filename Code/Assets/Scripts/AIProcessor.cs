using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIProcessor : MonoBehaviour {
	Animator anim;
	
	public Transform player;
	public Transform Troll;
	private float success;
	private float fail;
	private float playerSuccess;
	private float playerFail;
	private float combo1Count;
	private float combo2Count;
	private bool playerInRange;

	 // combo vars
    int noOfClicks = 0;
    //Time when last button was clicked
    float startTime = 0;
    float totalTime = 0;
    float lastClickedTime = 0;
    //Delay between clicks for which clicks will be considered as combo
    public float maxComboDelay = .3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int combo = comboController();
		if( combo == 1 ){
			
		}
		else if(combo == 2){
			
		}
		else{
			if(Input.GetKeyDown("space") || Input.GetButtonDown("X360_A")){
				
			}
			else if(Input.GetAxis("Vertical") || Input.GetAxis("Horizontal")){
				
			}
			else{
				
			}
		}
	}
	
	 int comboController() {
        // attack animation combos
        // this function could probably use some work

        if (totalTime == 0 && lastClickedTime == 0) {
            startTime = Time.time;
        }

        totalTime = Time.time - startTime;

        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("X360_B")) {
            lastClickedTime = Time.time;
            noOfClicks++;
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 2);
        }

        if(totalTime >= maxComboDelay) {
            Debug.Log("no clicks: " + noOfClicks);
            if (noOfClicks == 1) {
                noOfClicks = 0;
                return 1;
            } else if (noOfClicks == 2) {
                noOfClicks = 0;
                return 2;
            }
            noOfClicks = 0;
            lastClickedTime = 0;
            totalTime = 0;
            startTime = 0;
        }
        return 0;
    }
	
	bool inRange(){
		
	}
	//
	bool shouldAttack(){
		
	}
	//which attack should be used against the player
	String whichAttack(){
		
	}
}
