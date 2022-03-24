using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public float launchForce;
    public GameObject impactPrefab;
    public float timeUntilDestroy;
    public float targetDirectionY;
    private void Start()
    {
        Vector3 targetDirection = transform.forward;
        targetDirection.y = targetDirectionY;
        GetComponent<Rigidbody>().AddForce(targetDirection * launchForce, ForceMode.Impulse);
        Destroy(gameObject, timeUntilDestroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Geometry"))
        {
            Instantiate(impactPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
