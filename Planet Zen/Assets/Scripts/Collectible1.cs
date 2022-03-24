using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible1 : MonoBehaviour
{
    public GameObject mysteryImage;
    public GameObject title;
    public GameObject description;
    public GameObject recentDiscoveryIcon;

    public GameObject discoveryIcon;

    bool isDiscovered = false;

    public string itemName;
    public string itemDescription;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Player")
            return;
        if (isDiscovered)
        {
            return;
        }
        
        mysteryImage.SetActive(false);
        recentDiscoveryIcon.SetActive(true);
        title.GetComponent<TMPro.TextMeshProUGUI>().text = itemName;
        description.GetComponent<TMPro.TextMeshProUGUI>().text = itemDescription;

        //Play Sound
        StartCoroutine(showDiscoveryIcon());

        isDiscovered = true;
    }

    IEnumerator showDiscoveryIcon()
    {
        discoveryIcon.SetActive(true);

        yield return new WaitForSeconds(5);

        discoveryIcon.SetActive(false);
    }

}
