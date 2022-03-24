using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateSplatter : MonoBehaviour
{
    public float timeUntilDestroy;
    public float slowedSpeed;
    float formerSpeed;
    public List<PlayerMovement> currentlySlowed;

    void Start()
    {
        Destroy(gameObject, timeUntilDestroy);
    }

    private void OnDestroy()
    {
        if (currentlySlowed.Count > 0)
        {
            for (int i = 0; i < currentlySlowed.Count; i++)
            {
                currentlySlowed[i].moveSpeed = formerSpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (!currentlySlowed.Contains(playerMovement))
            {
                currentlySlowed.Add(playerMovement);
                formerSpeed = playerMovement.moveSpeed;
            }
            playerMovement.moveSpeed = slowedSpeed;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (currentlySlowed.Contains(playerMovement))
            {
                currentlySlowed.Remove(playerMovement);
            }
            playerMovement.moveSpeed = formerSpeed;
        }
    }
}
