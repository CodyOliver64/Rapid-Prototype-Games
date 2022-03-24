using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility2 : MonoBehaviour
{
    public GameObject abilityPrefab;
    public Transform abilitySpawnLocation;
    public Animator animator;
    public float abiltyCooldown, chargeCooldown;
    float nextAbilityTime = 0, nextCharge = 0;

    public AudioSource soundPlayer;
    public AudioClip abilitySound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button4) && Time.time > nextAbilityTime)
        {
            nextAbilityTime = Time.time + abiltyCooldown;
            Instantiate(abilityPrefab, abilitySpawnLocation.position, transform.rotation);
            soundPlayer.PlayOneShot(abilitySound);
            Debug.LogWarning(abilitySpawnLocation);
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && Time.time > nextCharge)
        {
            nextCharge = Time.time + chargeCooldown;
            animator.Play("Attack");
        }
    }
}
