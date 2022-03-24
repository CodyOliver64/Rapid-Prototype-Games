using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomRotation : MonoBehaviour
{
    bool hasNotRotated = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasNotRotated && other.gameObject.name == "Strawberry")
        {
            hasNotRotated = false;
            other.transform.Rotate(-40, other.transform.rotation.y, 0);
            Debug.Log("Rotating");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.Rotate(0, other.transform.rotation.y, 0);
    }
}
