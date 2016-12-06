using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

    CharacterController cc;
    public float movementSpeed = 9.0f;
    //public float mouseSensitivity = 4.0f;
    public float upDownRange = 85.0f;
    public float jumpForce = 20.0f;
    float verticalRotation = 0;
    float verticalVelocity = 0;

	// Use this for initialization
	void Start () {
        GameController.Reset();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (cc == null) {
            cc = GetComponent<CharacterController>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        //exit to main menu if cancel was pressed
        if (Input.GetButtonDown("Cancel"))
        {
            SceneChanger sc = new SceneChanger();
            sc.LoadSceneById(0);
        }

        Debug.Log("Updating First Person Controller and the mouse speed is: " + GameController.Instance.mouseSpeed, null);
        //Rotation

        float rotLeftRight = Input.GetAxisRaw("Mouse X") * GameController.Instance.mouseSpeed;
        transform.Rotate(0, rotLeftRight, 0);

        verticalRotation -= Input.GetAxisRaw("Mouse Y") * GameController.Instance.mouseSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        //gravity
        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        //jumping
        if (Input.GetButtonDown("Jump") && cc.isGrounded) {
            verticalVelocity = jumpForce;
        }
        

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;

        cc.Move(speed * Time.deltaTime);
	}
}
