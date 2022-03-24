using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMovement : MonoBehaviour
{
    public Rigidbody r;
    public float maxspeed;
    public float jumpforce;
    public bool canjump;

    private void FixedUpdate()
    {
        UpdateHorizontalMove();
        ClampOnMaxSpeed();
        Jump();
    }

    void UpdateHorizontalMove()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (r.velocity.z < maxspeed)
            {
                r.AddForce(r.transform.forward * maxspeed, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (r.velocity.z > -maxspeed)
            {
                r.AddForce(r.transform.forward * -maxspeed, ForceMode.VelocityChange);
            }
        }
    }

    void ClampOnMaxSpeed()
    {
        if (!Input.GetKey(KeyCode.D))
        {
            if (r.velocity.z > 0f)
            {
                r.AddForce(r.transform.forward * -r.velocity.z, ForceMode.VelocityChange);
            }
        }

        if (!Input.GetKey(KeyCode.A))
        {
            if (r.velocity.z < 0f)
            {
                r.AddForce(r.transform.forward * -r.velocity.z, ForceMode.VelocityChange);
            }
        }

        if (r.velocity.z > maxspeed)
        {
            r.AddForce(r.transform.forward * -(r.velocity.z - maxspeed), ForceMode.VelocityChange);
        }

        if (r.velocity.z < -maxspeed)
        {
            r.AddForce(r.transform.forward * -(r.velocity.z + maxspeed), ForceMode.VelocityChange);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (canjump)
            {
                r.AddForce(r.transform.up * jumpforce);
                canjump = false;
            }
        }
        else
        {
            canjump = true;
        }
    }
}