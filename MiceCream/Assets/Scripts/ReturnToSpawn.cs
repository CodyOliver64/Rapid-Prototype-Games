using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToSpawn : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2") || other.CompareTag("Player3") || other.CompareTag("Player4"))
        {
            other.transform.position = spawnPoint.position;
        }
    }
}
