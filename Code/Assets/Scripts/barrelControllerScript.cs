using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelControllerScript : MonoBehaviour {

	public GameObject barrel;
	public int numBarrels = 1;

	
	// Update is called once per frame
	void Update () {
		//Debug.Log(transform.childCount);
		if(transform.childCount < numBarrels) {
			Vector3 position = new Vector3(Random.Range(-100.0F, 100.0F), Random.Range(-100.0F, 100.0F), Random.Range(-100.0F, 100.0F));
			var newBarrel = Instantiate(barrel, position, Quaternion.identity);
			newBarrel.transform.parent = gameObject.transform; 
		}
	}
}
