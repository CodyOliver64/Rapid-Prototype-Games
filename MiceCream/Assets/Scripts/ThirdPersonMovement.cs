using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float rotateSpeed = 15f;

    public float gravity = 10f;
    public float constantGravity = -0.6f;
    public float maxGravity = -15f;

    private float currentGravity;
    private Vector3 gravityDirection;
    private Vector3 gravityMovement;

    
    private void Awake()
    {
        gravityDirection = Vector3.down;
    }
    
    void Update()
    {
        calculateGravity();
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        controller.Move(gravityMovement);

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }

        RotateTowardMovement(direction);
    }


    private void RotateTowardMovement(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0)
            return;

        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }



    private bool IsGrounded()
    {
        return controller.isGrounded;
    }
    private void calculateGravity()
    {
        if (IsGrounded())
        {
            currentGravity = constantGravity;
        }
        else
        {
            if (currentGravity > maxGravity)
            {
                currentGravity -= gravity * Time.deltaTime;
            }
        }

        gravityMovement = gravityDirection * -currentGravity * Time.deltaTime;
    }
}