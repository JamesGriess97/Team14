using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIProcessor : MonoBehaviour {
	Animator anim;
	
	public Transform player;
	public Transform troll;
	Troll troll;
	PlayerController player_Con;
	private float success;
	private float fail;
	private float playerSuccess;
	private float playerFail;
	private float combo1Count;
	private float combo2Count;
	private bool playerInRange;
	private bool retreat;

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
		retreat = Troll.isretreat();
		
		int combo = comboController();
		if( combo == 1 ){
			
		}
		else if(combo == 2){
			
		}
		else{
			

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
	//return whether or not the player is in range of either attack
	bool inRange(){
		
		return false;
	}
	//based on statistical analysis should/can the NPC attack
	bool shouldAttack(){
		
		return false;
	}
	//which attack should be used against the player
	int whichAttack(){
		
		return 0;
	}
}
