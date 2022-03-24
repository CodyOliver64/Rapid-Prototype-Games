using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemText;
    private GameObject blackScreen;

    private void Start()
    {
        blackScreen = GameObject.Find("Black Screen");
    }

    public void DestroyItem()
    {
        gameObject.SetActive(false);
    }

    public void OnItemHoverEnter()
    {
        itemText.text = $"Take {gameObject.tag}";
        itemText.gameObject.SetActive(true);
    }

    public void OnItemHoverExit()
    {
        itemText.gameObject.SetActive(false);
    }

    // Transponder

    public void OnTransponderHoverEnter()
    {
        itemText.text = $"Touch transponder";
        itemText.gameObject.SetActive(true);
    }

    public void ActivateTransponder()
    {
        StartCoroutine(SetOpacityAndVolume());
    }

    private IEnumerator SetOpacityAndVolume()
    {
        gameObject.GetComponent<AudioSource>().volume = 1.0f;
        Color blackScreenColor = blackScreen.gameObject.GetComponent<Image>().color;
        float opacity;
        float fadeSpeed = 5;

        while (blackScreenColor.a < 1)
        {
            opacity = blackScreenColor.a + (fadeSpeed * Time.deltaTime);
            blackScreenColor = new Color(0, 0, 0, opacity);
            blackScreen.gameObject.GetComponent<Image>().color = blackScreenColor;
            yield return null;
        }

        yield return new WaitForSeconds(21.5f);
        gameObject.GetComponent<AudioSource>().volume = 0.3f;

        while (blackScreenColor.a > 0)
        {
            opacity = blackScreenColor.a - (fadeSpeed * Time.deltaTime);
            blackScreenColor = new Color(0, 0, 0, opacity);
            blackScreen.gameObject.GetComponent<Image>().color = blackScreenColor;
            yield return null;
        }
    }
}
