using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility1 : MonoBehaviour
{
    public GameObject abilityPrefab;
    public Transform abilitySpawnLocation;
    public Animator animator;
    public float abiltyCooldown, chargeCooldown;
    public bool charging;
    float nextAbilityTime = 0, nextCharge = 0;


    public AudioSource soundPlayer;
    public AudioClip abilitySound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time > nextAbilityTime)
        {
            nextAbilityTime = Time.time + abiltyCooldown;
            Instantiate(abilityPrefab, abilitySpawnLocation.position, transform.rotation);
            soundPlayer.PlayOneShot(abilitySound);
        }
        else if(Input.GetKeyDown(KeyCode.Q) && Time.time > nextCharge)
        {
            nextCharge = Time.time + chargeCooldown;
            animator.Play("Attack");
        }
    }
}
