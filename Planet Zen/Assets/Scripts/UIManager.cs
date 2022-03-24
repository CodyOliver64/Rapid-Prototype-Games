using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject timePanel;


    // Flags
    private bool flagOne = false;
    private bool flagTwo = false;
    private bool flagThree = false;

    void Start()
    {
        StartCoroutine(DisplayWelcomeMessage());
    }

    void Update()
    {
        StartTimeDisplay();
    }

    private void StartTimeDisplay()
    {
        if (gameManager.minutesPassed == 1 && !flagOne)
        {
            flagOne = true;
            StartCoroutine(DisplayTimeWarning());
        }
        else if (gameManager.minutesPassed == 2 && !flagTwo)
        {
            flagThree = true;
            StartCoroutine(DisplayTimeWarning());
        }
        else if (gameManager.minutesPassed == 5 && !flagThree)
        {
            flagThree = true;
            StartCoroutine(DisplayTimeWarning());
        }
    }

    private IEnumerator DisplayTimeWarning()
    {
        if (gameManager.minutesPassed == 1)
        {
            timePanel.GetComponentInChildren<TextMeshProUGUI>().text = "Hello there. You've been playing for more than an hour.";
            yield return new WaitForSeconds(0.2f);
            timePanel.SetActive(true);
            yield return new WaitForSeconds(6.0f);
            timePanel.SetActive(false);
        }

        else if (gameManager.minutesPassed == 2)
        {
            flagTwo = true;
            timePanel.GetComponentInChildren<TextMeshProUGUI>().text = "Hello there. You've been playing for a couple hours.";
            yield return new WaitForSeconds(0.2f);
            timePanel.SetActive(true);
            yield return new WaitForSeconds(6.0f);
            timePanel.SetActive(false);
        }

        else if (gameManager.minutesPassed == 5 && !flagThree)
        {
            flagThree = true;
            timePanel.GetComponentInChildren<TextMeshProUGUI>().text = "Hello there. You've been playing for awhile. ";
            yield return new WaitForSeconds(0.2f);
            timePanel.SetActive(true);
            yield return new WaitForSeconds(6.0f);
            timePanel.SetActive(false);
        }
    }

    private IEnumerator DisplayWelcomeMessage()
    {
        Color baseColor = timePanel.gameObject.GetComponent<Image>().color;
        timePanel.GetComponentInChildren<TextMeshProUGUI>().text = "Greetings from Planet Zen! You're a space explorer who crash landed onto this peaceful planet, but it just so happens you were on your way here anyways! Known to be one of the safest spots in space, take this opportunity to look around everything Planet Zen has to offer, let this experience be your getaway from reality. Explore and fill up your journal with a different assortment of collectibles that you'll be able to find in this alien world. Be wary though, not everything on this planet is suitable for humans so take precaution if you see any warning signs. We hope you enjoy your visit at Planet Zen and hope to see you back soon.";
        timePanel.gameObject.GetComponent<Image>().color = new Color(timePanel.gameObject.GetComponent<Image>().color.r, timePanel.gameObject.GetComponent<Image>().color.g, timePanel.gameObject.GetComponent<Image>().color.b, 1);
        yield return new WaitForSeconds(0.2f);
        timePanel.SetActive(true);
        yield return new WaitForSeconds(15.0f);
        timePanel.SetActive(false);
        timePanel.gameObject.GetComponent<Image>().color = baseColor;
    }
}
