using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement4 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 75f;
    public float jumpForce = 5f;
    public Camera camera;
    public Rigidbody rb;

    public bool isGrounded = false;

    public AudioSource soundPlayer;
    public AudioClip jumpSound;

    private Vector3 movement;
    private Vector3 rotation;
    private Vector2 mouseInput;

    // Update is called once per frame
    void Update()
    {
        
        
        movement = new Vector3(0f, 0f, Input.GetAxis("Vertical4"));
        rotation = new Vector3(Input.GetAxis("Horizontal4"), 0f, 0f);



        var movementVector = MoveTowardTarget(movement);

        //RotateTowardMovement(movementVector);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;

        Vector3 moveVector = transform.TransformDirection(targetVector) * moveSpeed;
        rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);

        if (Input.GetKeyDown(KeyCode.Joystick3Button3) && isGrounded && moveSpeed >= 5f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            soundPlayer.PlayOneShot(jumpSound);
        }


        transform.Rotate(0f, rotation.x * rotateSpeed * Time.deltaTime, 0f);
        
        targetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * targetVector;

        return targetVector;
    }
    
    
    private void RotateTowardMovement(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0)
            return;
        
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    void OnCollisionStay(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Floor")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Floor")
        {
            isGrounded = false;
        }
    }
}
