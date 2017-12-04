using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trollArmActivator : MonoBehaviour {

    Collider armCollider;
    
    public GameObject arm;

    // Use this for initialization
    void Start () {
        armCollider = arm.GetComponent<Collider>();

        //Here the GameObject's Collider is not a trigger
        armCollider.isTrigger = false;
        //Output whether the Collider is a trigger type Collider or not
        Debug.Log("Trigger On : " + armCollider.isTrigger);
    }

    void armTrigger() {
        armCollider.isTrigger = true;
    }

    void disableTrigger() {
        armCollider.isTrigger = false;
    }
}
