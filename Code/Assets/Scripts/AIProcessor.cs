using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIProcessor : MonoBehaviour {
	//Component variables
	Animator anim;
	public Transform player;
	public Transform troll;
	Troll troll_ob;
	PlayerController player_Con;
	float distance;
	
	//AI Estimation and decision variables
	private float success;
	private float fail;
	private float attackTimer;
	private float attackTimerStart;
	private float attack1Lambda;
	private float attack2Lambda;
	private float lastAttack1TimerStart;
	private float lastAttack1Timer;
	private float lastAttack2TimerStart;
	private float lastAttack2Timer;
	private float combo1Count;
	private float combo2Count;
	private float attack1Odds;
	private float attack2Odds;
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
		attackTimerStart = Time.time;
		lastAttack1TimerStart = 0;
		lastAttack2TimerStart = 0;
	}
	
	// Update is called once per frame
	void Update () {
		

		
		int combo = comboController();
		if( combo == 1 ){
			combo1Count++;
			lastAttack1TimerStart = Time.time;
		}
		else if(combo == 2){
			combo2Count ++;	
			lastAttack2TimerStart = Time.time;
			
		}

		lastAttack1Timer = Time.time - lastAttack1TimerStart;
		lastAttack2Timer = Time.time - lastAttack2TimerStart;
		attackTimer = Time.time - attackTimerStart;
		attack1Lambda = combo1Count/attackTimer;
		attack2Lambda = combo2Count/attackTimer;
		
		attack1Odds = poissonEstimate(1.0f, attack1Lambda, lastAttack1Timer);
		attack2Odds = poissonEstimate(1.0f, attack2Lambda, lastAttack2Timer);
		distance = Vector3.Distance(troll.position, player.position);
		
		
		
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
	public bool inRange(){
		if(distance < 3f){
			return true;
		}
		else{
			return false;
		}
	}
	public bool inPlayerRange(){
		if(distance < 3.3f){
			return true;
		}
		else{
			return false;
		}
	}
	//based on statistical analysis should/can the NPC attack
	public bool shouldAttack(){
		if(inRange()){
			if(!inPlayerRange()){
				return true;
			}
			else{
				if((attack1Odds < 0.89f)&&(attack2Odds < 0.89f)){
					return true;
				}
				else{
					return false;
				}
			}
		}
		else{
			return false;
		}
	}
	
	public bool shouldStepBack(){
		if((inPlayerRange()) && (attack2Odds > 0.75f)){
			return true;
		}
		else{
			return false;
		}
	}
	
	//get the poisson estimate how likely something is to occur in a set period of time
	float poissonEstimate(float x,float lambda,float t){
		float prob;
		float L = lambda * t;
		float e = 2.7f;
		prob = (Mathf.Pow(e,L) * Mathf.Pow(L,x))/factorial(x);
		
		return prob;
		
	}
	
	float factorial(float a){
		float fact = 1.0f;
		
		for(int i = 1; i <= a; i++){
			fact = fact * i;
		}
		
		return fact;
	}

}
