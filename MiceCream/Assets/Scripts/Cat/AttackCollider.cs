using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public EnemyAI catAI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2") || other.CompareTag("Player3") || other.CompareTag("Player4"))
        {
            catAI.playerInAttackRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2") || other.CompareTag("Player3") || other.CompareTag("Player4"))
        {
            catAI.playerInAttackRange = false;
        }
    }
}
