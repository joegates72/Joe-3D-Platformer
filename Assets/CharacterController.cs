using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
 float maxSpeed;
 public float normalSpeed = 15.0f;
 public float sprintSpeed = 25.0f;
 
 float rotation = 0.0f;
 float camRotation = 0.0f;

 GameObject cam;
 Rigidbody myRigidbody;

 bool isOnGround;
 public GameObject groundChecker;
 public LayerMask groundLayer;
 public float jumpForce = 320.0f;

 float rotationSpeed = 2.0f;
 float camRotationSpeed = 2.0f;

 public float maxSprint = 5.0f;
 float sprintTimer;

 void Start()
 {
     Cursor.lockState = CursorLockMode.Locked;

     sprintTimer = maxSprint;

     cam = GameObject.Find("Main Camera");
     myRigidbody = GetComponent<Rigidbody>();
 }
    // Update is called once per frame
    void Update()
    {
     isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);

     if(isOnGround == true && Input.GetKeyDown(KeyCode.Space))
     {
         myRigidbody.AddForce(transform.up * jumpForce);
     }

     if(Input.GetKey(KeyCode.LeftShift) && sprintTimer > 0.0f)
     {
         maxSpeed = sprintSpeed;
     } else
     {
         maxSpeed = normalSpeed;
     }

     if (Input.GetKey(KeyCode.LeftShift))
     {
         maxSpeed = sprintSpeed;
     } else
     {
         maxSpeed = normalSpeed;
     }

        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y");
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));
    }
}
