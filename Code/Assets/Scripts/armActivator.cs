using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armActivator : MonoBehaviour {

    Collider armCollider;
    Collider footCollider;
    
    public GameObject arm;
    public GameObject foot;

    // Use this for initialization
    void Start () {
        armCollider = arm.GetComponent<Collider>();
        footCollider = foot.GetComponent<Collider>();

        //Here the GameObject's Collider is not a trigger
        armCollider.isTrigger = false;
        footCollider.isTrigger = false;
        //Output whether the Collider is a trigger type Collider or not
        Debug.Log("Trigger On : " + armCollider.isTrigger);
    }

    void armTrigger() {
        armCollider.isTrigger = true;
    }

    void footTrigger() {
        footCollider.isTrigger = true;
    }

    void disableTrigger() {
        armCollider.isTrigger = false;
        footCollider.isTrigger = false;
    }
}
