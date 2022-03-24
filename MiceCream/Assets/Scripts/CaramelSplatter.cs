using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaramelSplatter : MonoBehaviour
{
    public float timeUntilDestroy;
    public float slowedSpeed;
    float formerSpeed = 5;
    public List<PlayerMovement> currentlySlowed;
    public List<PlayerMovement2> currentlySlowed2;
    public List<PlayerMovement3> currentlySlowed3;
    public List<PlayerMovement4> currentlySlowed4;


    void Start()
    {
        if(timeUntilDestroy > 0f)
        {
            Destroy(gameObject, timeUntilDestroy);
        }
        
    }

    private void OnDestroy()
    {
        if(currentlySlowed.Count > 0)
        {
            for(int i = 0; i < currentlySlowed.Count; i++)
            {
                currentlySlowed[i].moveSpeed = formerSpeed;
            }
        }

        if (currentlySlowed2.Count > 0)
        {
            for (int i = 0; i < currentlySlowed2.Count; i++)
            {
                currentlySlowed2[i].moveSpeed = formerSpeed;
            }
        }

        if (currentlySlowed3.Count > 0)
        {
            for (int i = 0; i < currentlySlowed3.Count; i++)
            {
                currentlySlowed3[i].moveSpeed = formerSpeed;
            }
        }

        if (currentlySlowed4.Count > 0)
        {
            for (int i = 0; i < currentlySlowed4.Count; i++)
            {
                currentlySlowed4[i].moveSpeed = formerSpeed;
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
                //formerSpeed = playerMovement.moveSpeed;
            }
            playerMovement.moveSpeed = slowedSpeed;
        }

        if (other.CompareTag("Player2"))
        {
            PlayerMovement2 playerMovement = other.GetComponent<PlayerMovement2>();
            if (!currentlySlowed2.Contains(playerMovement))
            {
                currentlySlowed2.Add(playerMovement);
                //formerSpeed = playerMovement.moveSpeed;
            }
            playerMovement.moveSpeed = slowedSpeed;
        }

        if (other.CompareTag("Player3"))
        {
            PlayerMovement3 playerMovement = other.GetComponent<PlayerMovement3>();
            if (!currentlySlowed3.Contains(playerMovement))
            {
                currentlySlowed3.Add(playerMovement);
                //formerSpeed = playerMovement.moveSpeed;
            }
            playerMovement.moveSpeed = slowedSpeed;
        }

        if (other.CompareTag("Player4"))
        {
            PlayerMovement4 playerMovement = other.GetComponent<PlayerMovement4>();
            if (!currentlySlowed4.Contains(playerMovement))
            {
                currentlySlowed4.Add(playerMovement);
                //formerSpeed = playerMovement.moveSpeed;
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
        if (other.CompareTag("Player2"))
        {
            PlayerMovement2 playerMovement = other.GetComponent<PlayerMovement2>();
            if (currentlySlowed2.Contains(playerMovement))
            {
                currentlySlowed2.Remove(playerMovement);
            }
            playerMovement.moveSpeed = formerSpeed;
        }
        if (other.CompareTag("Player3"))
        {
            PlayerMovement3 playerMovement = other.GetComponent<PlayerMovement3>();
            if (currentlySlowed3.Contains(playerMovement))
            {
                currentlySlowed3.Remove(playerMovement);
            }
            playerMovement.moveSpeed = formerSpeed;
        }
        if (other.CompareTag("Player4"))
        {
            PlayerMovement4 playerMovement = other.GetComponent<PlayerMovement4>();
            if (currentlySlowed4.Contains(playerMovement))
            {
                currentlySlowed4.Remove(playerMovement);
            }
            playerMovement.moveSpeed = formerSpeed;
        }
    }

     

}
