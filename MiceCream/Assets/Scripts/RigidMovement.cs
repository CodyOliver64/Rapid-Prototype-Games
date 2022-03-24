using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMovement : MonoBehaviour
{
    public Rigidbody playerBody;
    public Transform playerCamera;
    public float moveSpeed;
    public float camSpeed;
    public float jumpForce;

    private Vector3 playerMovementInput;
    private Vector3 playerMouseInput;


    void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();
    }


    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * moveSpeed;
        playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
