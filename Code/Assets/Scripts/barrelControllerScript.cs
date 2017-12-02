using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelControllerScript : MonoBehaviour {

	public GameObject barrel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(transform.childCount);
		if(transform.childCount < 2) {
			var newBarrel = Instantiate(barrel);
			newBarrel.transform.parent = gameObject.transform; 
		}
	}
}
