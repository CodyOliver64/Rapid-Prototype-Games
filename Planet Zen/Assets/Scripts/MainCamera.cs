using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject cameraPosition;

    private void LateUpdate()
    {
        transform.position = cameraPosition.transform.position;
    }
}
