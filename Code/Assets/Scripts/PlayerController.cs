﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Transform playerCam, character, centerPoint;

    private float mouseX, mouseY;
    public float mouseSensitivity = 10f;
    public float mouseYPosition = 1f;

    private float moveFB, moveLR;
    public float moveSpeed = 2f;

    public float rotationSpeed = 5f;



    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, 10, 60f);

        playerCam.LookAt(centerPoint);
        centerPoint.localRotation = Quaternion.Euler(mouseY, mouseX, 0);

        moveFB = Input.GetAxis("Vertical") * moveSpeed;
        moveLR = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        movement = character.rotation * movement;
        character.GetComponent<CharacterController>().Move(movement * Time.deltaTime);
        centerPoint.position = new Vector3(character.position.x, character.position.y + mouseYPosition, character.position.z);

        if (Input.GetAxis("Vertical") > 0 | Input.GetAxis("Vertical") < 0) {

            Quaternion turnAngle = Quaternion.Euler(0, centerPoint.eulerAngles.y, 0);

            character.rotation = Quaternion.Slerp(character.rotation, turnAngle, Time.deltaTime * rotationSpeed);

        }

    }
}