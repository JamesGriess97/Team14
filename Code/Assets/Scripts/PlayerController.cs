using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Transform playerCam, character, centerPoint;
    private Rigidbody rb;

    private float mouseX, mouseY;
    public float mouseSensitivity = 10f;
    public float mouseYPosition = 1f;

    private float moveFB, moveLR;
    public float moveSpeed = 2f;

    public float rotationSpeed = 5f;



    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        // get mouse input
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, 10, 60f);

        playerCam.LookAt(centerPoint);
        centerPoint.localRotation = Quaternion.Euler(mouseY, mouseX, 0);

        // get keyboard input
        moveFB = Input.GetAxis("Vertical") * moveSpeed;
        moveLR = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 movement = new Vector3(moveLR, 0, moveFB);

        Quaternion lookAngle = Quaternion.LookRotation(movement, Vector3.up);
        Quaternion cameraAngle = Quaternion.Euler(0, centerPoint.eulerAngles.y, 0);
        Quaternion turnAngle = lookAngle * cameraAngle;

        movement = cameraAngle * movement;

        // move the player and update rotation and centerpoint
        character.GetComponent<CharacterController>().Move(movement * Time.deltaTime);
        character.rotation = Quaternion.Slerp(character.rotation, turnAngle, Time.deltaTime * rotationSpeed);
        centerPoint.position = new Vector3(character.position.x, character.position.y + mouseYPosition, character.position.z);
    }
}