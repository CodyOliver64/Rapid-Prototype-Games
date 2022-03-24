using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // References
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private GameObject cameraHolder;
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private CapsuleCollider capsuleCollider;
    [SerializeField] private CapsuleCollider capsuleColliderShell;
    [SerializeField] private PlayerInput playerInput;
    private Rigidbody playerRb;

    // Drag
    private float groundedDrag = 6.0f;
    private float airDrag = 1.0f;

    // Jumping
    [Header("Jumping")]
    [SerializeField] private LayerMask groundMask;
    [Range(1.0f, 10.0f)] [SerializeField] private float jumpForce = 5.0f;
    private float jumpForceMultiplier = 1.8f;
    private bool jumpReady = true;
    private bool isGrounded;
    private float sphereRadius = 0.35f; // Ground Detection
    private float fallMultiplier = 1.15f;

    // Slopes
    private RaycastHit slopeHit;
    private float slopeAngle;
    private float slopeNormalized;
    private float slopeSpeed;

    // Movement
    [Header("Movement")]
    [Range(1.0f, 10.0f)] [SerializeField] private float walkSpeed = 3.0f;
    [Range(1.0f, 10.0f)] [SerializeField] private float sprintSpeed = 6.0f;
    private float speed = 6.0f;
    private float speedMultiplier = 10.0f;
    private float acceleration = 10.0f;
    private bool sprintInput;
    private Vector2 moveValue;
    private Vector3 moveDirection;
    private Vector3 slopeMoveDirection;
    private float airSpeedMultiplier = 0.4f;

    // Crouch
    [Header("Crouch")]
    private float crouchSpeedMultiplier = 1;
    private float capsuleBaseHeight;
    private float capsuleTargetHeight;
    private float capsuleShellBaseHeight;
    private float capsuleShellTargetHeight;
    private Vector3 cameraBasePosition;
    private Vector3 cameraTargetPosition;
    private float capsuleVelo;
    private float capsuleShellVelo;
    private Vector3 cameraVelo = Vector3.zero;
    private bool isCrouched;

    // Mouse/Camera
    [Header("Look Controls")]
    [Range(1.0f, 10.0f)] [SerializeField] private float sensitivity = 5.0f; // Mouse sensitivity
    private Vector2 lookValue;
    private float sensitivityMultiplier = 13.5f;
    private float mouseX; // Mouse X axis movement
    private float cameraYRotation; // Camera Y axis rotation
    private float mouseY; // Mouse Y axis Movement
    private float cameraXRotation; // Camera X axis rotation

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        playerRb.freezeRotation = true; // prevents physics from affecting rotation
        Cursor.lockState = CursorLockMode.Locked; // Hide Cursor

        // Crouch Height/Camera Position Set
        capsuleBaseHeight = capsuleCollider.height;
        capsuleTargetHeight = capsuleBaseHeight;
        capsuleShellBaseHeight = capsuleColliderShell.height;
        capsuleShellTargetHeight = capsuleShellBaseHeight;
        cameraBasePosition = cameraPosition.localPosition;
        cameraTargetPosition = cameraBasePosition;
    }

    private void Update()
    {
        // Jumping
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, capsuleCollider.height / 2, 0), sphereRadius, groundMask); // Jumping controlled by new Input System

        // Slope Move direction
        SlopeMovement();

        // Movement Speed
        ControlSpeed();

        // Crouch
        capsuleCollider.height = Mathf.SmoothDamp(capsuleCollider.height, capsuleTargetHeight, ref capsuleVelo, 0.1f);
        capsuleColliderShell.height = Mathf.SmoothDamp(capsuleColliderShell.height, capsuleShellTargetHeight, ref capsuleShellVelo, 0.1f);
        cameraPosition.localPosition = Vector3.SmoothDamp(cameraPosition.localPosition, cameraTargetPosition, ref cameraVelo, 0.1f);

        // Mouse/Camera
        LookControls();
    }

    private void FixedUpdate()
    {
        // Player Movement
        Move();

        // Set Player Drag
        SetDrag();

        // Fall Speed
        FallSpeed();
    }

    private void ControlSpeed()
    {
        if (sprintInput && isGrounded && !isCrouched)
        {
            speed = Mathf.Lerp(speed, sprintSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            speed = Mathf.Lerp(speed, walkSpeed, acceleration * Time.deltaTime);
        }
    }

    private void Move()
    {
        // Movement Direction
        moveDirection = orientation.forward * moveValue.y + orientation.right * moveValue.x;
        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);

        // Movement
        if (isGrounded && !OnSlope())
        {
            playerRb.AddForce(moveDirection.normalized * speed * speedMultiplier * crouchSpeedMultiplier, ForceMode.Acceleration);
        }
        else if (isGrounded && OnSlope())
        {
            playerRb.AddForce(slopeMoveDirection.normalized * slopeSpeed * speedMultiplier * crouchSpeedMultiplier, ForceMode.Acceleration);
        }
        else if (!isGrounded)
        {
            playerRb.AddForce(moveDirection.normalized * speed * speedMultiplier * airSpeedMultiplier * crouchSpeedMultiplier, ForceMode.Acceleration);
        }
    }


    private void SetDrag()
    {
        if(isGrounded)
        {
            playerRb.drag = groundedDrag;
        }
        else
        {
            playerRb.drag = airDrag;
        }
    }

    private void SlopeMovement()
    {
        float slopeAng = -1 * (Vector3.Angle(slopeMoveDirection, transform.up) - 90);
        if (slopeAng != 90) { slopeAngle = slopeAng; } // prevents showing 90 when standing still. Instead shows previous angle
        slopeNormalized = slopeAngle / -90; // Makes the slope angle a multiplier
        slopeSpeed = speed + speed * slopeNormalized;
    }

    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, capsuleCollider.height / 2 + 0.5f)) // Straight down from player
        {
            if (slopeHit.normal != Vector3.up) // if normal of collided object's mesh is not straight up
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void LookControls()
    {
        // Set Sensitivity Multiplier
        if (playerInput.currentControlScheme == "Keyboard/Mouse") { sensitivityMultiplier = 12; }
        else { sensitivityMultiplier = 50; }

        // Player Horizontal Rotation
        mouseX = lookValue.x;
        cameraYRotation += mouseX * sensitivity * sensitivityMultiplier * Time.deltaTime;
        orientation.rotation = Quaternion.Euler(0, cameraYRotation, 0);

        // Camera Rotation
        mouseY = lookValue.y;
        cameraXRotation -= mouseY * sensitivity * sensitivityMultiplier * Time.deltaTime;
        cameraXRotation = Mathf.Clamp(cameraXRotation, -90.0f, 90.0f); // Clamp Rotation
        cameraHolder.transform.localRotation = Quaternion.Euler(cameraXRotation, cameraYRotation, 0f);
    }

    private void FallSpeed()
    {
        if (playerRb.velocity.y < 0 && !isGrounded) // if falling
        {
            playerRb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime; // increase downward gravity
        }
    }

    IEnumerator CrouchDrop()
    {
        yield return new WaitForSeconds(0.1f);
        playerRb.AddForce(Vector3.down * 2, ForceMode.Impulse); // Quick drop to ground
    }

    // Input Functions:

    private void OnJump()
    {
        if (isGrounded && jumpReady)
        {
            playerRb.AddForce(Vector3.up * jumpForce * jumpForceMultiplier, ForceMode.Impulse);
            jumpReady = false;
        }
    }

    private void OnSprint(InputValue value)
    {
        sprintInput = value.isPressed;
    }

    private void OnCrouch()
    {
        if (!isCrouched)
        {
            capsuleTargetHeight = capsuleBaseHeight / 1.8f;
            capsuleShellTargetHeight = capsuleShellBaseHeight / 2;
            cameraTargetPosition = cameraBasePosition * 0.66f;
            isCrouched = true;
            crouchSpeedMultiplier = 0.5f;
            StartCoroutine(CrouchDrop()); // Quick drop to ground
        }
        else
        {
            capsuleTargetHeight = capsuleBaseHeight;
            capsuleShellTargetHeight = capsuleShellBaseHeight;
            cameraTargetPosition = cameraBasePosition;
            isCrouched = false;
            crouchSpeedMultiplier = 1f;
        }
    }

    private void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    private void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isGrounded) { jumpReady = true; } // fix for mini-jumps
    }
}

