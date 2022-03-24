using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    void Awake()
    {
        rb.AddForce(new Vector3(0, 0, 25), ForceMode.Impulse);
    }

    public IEnumerator Kill()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            //play sound?
            Destroy(gameObject);
        }
    }
}
