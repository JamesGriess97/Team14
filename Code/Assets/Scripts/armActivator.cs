using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armActivator : MonoBehaviour {

    Collider armCollider;
    Collider footCollider;
    
    public GameObject arm;

    // Use this for initialization
    void Start () {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        armCollider = arm.GetComponent<Collider>();
        //Here the GameObject's Collider is not a trigger
        armCollider.isTrigger = false;
        //Output whether the Collider is a trigger type Collider or not
        Debug.Log("Trigger On : " + armCollider.isTrigger);
    }

    void activateTrigger() {
        //GameObject's Collider is now a trigger Collider when the GameObject is clicked. It now acts as a trigger
        armCollider.isTrigger = true;
        //Output to console the GameObject’s trigger state
        Debug.Log("Trigger On : " + armCollider.isTrigger);
    }

    void disableTrigger() {
        armCollider.isTrigger = false;
    }
}
