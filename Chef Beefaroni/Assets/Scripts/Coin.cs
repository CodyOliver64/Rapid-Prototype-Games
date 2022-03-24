using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int money;
    public bool upgradeCoin = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            UpgradeManager temp = other.GetComponent<PlayerManager>().upgradeManager;
            if (!upgradeCoin)
            {
              
                temp.currentMoney += money;
                temp.UpdateMoneyText();
            }
            else
            {
                PlayerManager tempPM = other.GetComponent<PlayerManager>();
                tempPM.abilityUses++;
                tempPM.SpecialAbilityUsesText.text = tempPM.abilityUses.ToString();
            }


            GameObject.Find("CoinSFX").GetComponent<AudioSource>().Play();


            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }
}
