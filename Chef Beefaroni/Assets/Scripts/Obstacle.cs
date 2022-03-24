using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerManager PM = other.GetComponent<PlayerManager>();
            PM.LoseHealth();
            PM.currentSpeed = PM.currentSpeed / 2;

            AudioSource clangNoise = GameObject.Find("SFX").GetComponent<AudioSource>();
            clangNoise.Play();

            //Slow Player?
            Destroy(gameObject);
        }
    }
}
