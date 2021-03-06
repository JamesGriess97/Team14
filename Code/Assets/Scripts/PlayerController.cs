﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Transform playerCam, character, centerPoint;
    private Rigidbody rb;
	public Transform healthSlider;

    private float mouseX, mouseY;
    public float mouseSensitivity = 10f;
    public float mouseYPosition = 1f;

    private float moveFB, moveLR;
    public float moveSpeed = 2f;

    public float rotationSpeed = 5f;
    public float lookSpeed = 1f;

    // gravity 
    public float jumpSpeed = 8f;
    public float gravity = 9.8f;
    private float vSpeed = 0f;

    // animator
    Animator anim;


    // combo vars
    int noOfClicks = 0;
    //Time when last button was clicked
    float startTime = 0;
    float totalTime = 0;
    float lastClickedTime = 0;
    //Delay between clicks for which clicks will be considered as combo
    public float maxComboDelay = .3f;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() {
		healthSlider.position = character.position;
        // jump animation
        if(character.GetComponent<CharacterController>().isGrounded) {
            vSpeed = 0f;
            if (Input.GetKeyDown("space") || Input.GetButtonDown("X360_A")) {
                vSpeed = jumpSpeed;
                anim.SetBool("Jump", true);
            } else {
                anim.SetBool("Jump", false);
            }
        }
        vSpeed -= gravity * Time.deltaTime;

        // get mouse input
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        mouseX += (lookSpeed * Input.GetAxis("X360_RStickX"));
        mouseY += (lookSpeed * Input.GetAxis("X360_RStickY"));

        mouseY = Mathf.Clamp(mouseY, 0, 60f);

        playerCam.LookAt(centerPoint);
        centerPoint.localRotation = Quaternion.Euler(mouseY, mouseX, 0);

        // get keyboard input
        moveFB = Input.GetAxis("Vertical") * moveSpeed;
        moveLR = Input.GetAxis("Horizontal") * moveSpeed;
        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        Quaternion lookAngle;
        Quaternion cameraAngle;
        Quaternion turnAngle;

        cameraAngle = Quaternion.Euler(0, centerPoint.eulerAngles.y, 0);
        if(movement != Vector3.zero) {
            lookAngle = Quaternion.LookRotation(movement, Vector3.up);
            turnAngle = lookAngle * cameraAngle;
        } else {
            turnAngle = character.rotation;
        }


        movement = cameraAngle * movement;
        movement.y = movement.y + vSpeed;

        // move the player and update rotation and centerpoint
        character.GetComponent<CharacterController>().Move(movement * Time.deltaTime);
        character.rotation = Quaternion.Slerp(character.rotation, turnAngle, Time.deltaTime * rotationSpeed);
        centerPoint.position = new Vector3(character.position.x, character.position.y + mouseYPosition, character.position.z);


        int combo = comboController();
        if(combo == 1) {
            anim.SetBool("Attack", true);
        } else if (combo == 2) {
            anim.SetBool("Kick", true);
        }
      
        float vert = Mathf.Abs(Input.GetAxis("Vertical"));
        float horiz = Mathf.Abs(Input.GetAxis("Horizontal"));

        // walk animation
        if(vert + horiz != 0) {
            float speed = Mathf.Clamp((vert + horiz)/2 * 3, .6f, 1.5f);
            anim.SetFloat("Speed", speed);
        } else {
            anim.SetFloat("Speed", 0);
        }
    }

    int comboController() {
        // attack animation combos
        // this function could probably use some work

        if(noOfClicks == 0 && (anim.GetCurrentAnimatorStateInfo(0).IsName("AttackPunch") || anim.GetCurrentAnimatorStateInfo(0).IsName("AttackKick")) ) {
            anim.SetBool("Attack", false);
            anim.SetBool("Kick", false);
        }
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
            //Debug.Log("no clicks: " + noOfClicks);
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
}