using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public bool IsAlive = true;
	public int health;
	// Use this for initialization
	void Start () {
		IsAlive = true;
		health = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
