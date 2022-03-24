using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UpgradeManager : MonoBehaviour
{
    public GameObject purchaseUI;

    //UI Elements
    public GameObject moneyText;
    public GameObject notEnoughMoneyText;
    public GameObject steelButton;
    public GameObject goldButton;
    public GameObject dentedButton;
    public GameObject smoothButton;
    public GameObject upgrade2Button;
    public GameObject upgrade3Button;

    //Player Paramters
    public int currentMoney = 5000;
    public float maxHealth = 1;
    public float maxSpeed = 17.5f;
    public int ability = 0;

    //Upgrade Costs
    int steelCost = 500;
    int goldCost = 1000;
    int dentedCost = 500;
    int smoothCost = 1000;
    int upgrade2Cost = 500;
    int upgrade3Cost = 1000;

    [Header("Can Models")]
    public Mesh[] models;
    public int currentModel = 0;
    public int currentMetal = 0;
    public int currentLabel = 0;


    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Respawn");

        foreach(GameObject obj in objs)
        {
            DontDestroyOnLoad(obj);
        }

      // if (objs.Length > 1)
      // {
      //     Destroy(this.gameObject);
      // }
      //
      // DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        moneyText.GetComponent<Text>().text = "$" + currentMoney.ToString();
    }

    public void UpdateMoneyText()
    {
        moneyText.GetComponent<Text>().text = "$" + currentMoney.ToString();
    }

    public void UpgradeToSteel()
    {
        //If player does not have enough money
        if (currentMoney < steelCost)
        {
            StartCoroutine(ShowNotEnoughMessage());
        }

        //upgrade and set icons
        else
        {
            //set old icon
            steelButton.GetComponent<Button>().interactable = false;
            steelButton.transform.GetChild(1).GetComponent<Text>().text = "Purchased";
            steelButton.transform.GetChild(1).GetComponent<Text>().color = new Color32(59, 255, 0, 255);

            //set next Icon
            goldButton.GetComponent<Button>().interactable = true;
            goldButton.transform.GetChild(1).GetComponent<Text>().text = goldCost.ToString();
            goldButton.transform.GetChild(1).GetComponent<Text>().color = new Color32(255, 217, 0, 255);

            //update money
            currentMoney -= steelCost;
            moneyText.GetComponent<Text>().text = "$" + currentMoney.ToString();

            //play sound


            //update player parameters
            currentMetal++;
            maxHealth = 2;
        }
    }
    public void UpgradeToGold()
    {
        //If player does not have enough money
        if (currentMoney < goldCost)
        {
            StartCoroutine(ShowNotEnoughMessage());
        }

        //upgrade and set icons
        else
        {
            //set old icon
            goldButton.GetComponent<Button>().interactable = false;
            goldButton.transform.GetChild(1).GetComponent<Text>().text = "Purchased";
            goldButton.transform.GetChild(1).GetComponent<Text>().color = new Color32(59, 255, 0, 255);

            //update money
            currentMoney -= goldCost;
            moneyText.GetComponent<Text>().text = "$" + currentMoney.ToString();

            //play sound

            //update player parameters
            currentMetal++;
            maxHealth = 3;
        }
    }

    public void UpgradeToDented()
    {
        //If player does not have enough money
        if (currentMoney < dentedCost)
        {
            StartCoroutine(ShowNotEnoughMessage());
        }

        //upgrade and set icons
        else
        {
            //set old icon
            dentedButton.GetComponent<Button>().interactable = false;
            dentedButton.transform.GetChild(1).GetComponent<Text>().text = "Purchased";
            dentedButton.transform.GetChild(1).GetComponent<Text>().color = new Color32(59, 255, 0, 255);

            //set next Icon
            smoothButton.GetComponent<Button>().interactable = true;
            smoothButton.transform.GetChild(1).GetComponent<Text>().text = smoothCost.ToString();
            smoothButton.transform.GetChild(1).GetComponent<Text>().color = new Color32(255, 217, 0, 255);

            //update money
            currentMoney -= dentedCost;
            moneyText.GetComponent<Text>().text = "$" + currentMoney.ToString();

            //play sound


            //update player parameters
            currentModel++;
            maxSpeed = 22.5f;
        }
    }
    public void UpgradeToSmooth()
    {
        //If player does not have enough money
        if (currentMoney < smoothCost)
        {
            StartCoroutine(ShowNotEnoughMessage());
        }

        //upgrade and set icons
        else
        {
            //set old icon
            smoothButton.GetComponent<Button>().interactable = false;
            smoothButton.transform.GetChild(1).GetComponent<Text>().text = "Purchased";
            smoothButton.transform.GetChild(1).GetComponent<Text>().color = new Color32(59, 255, 0, 255);

            //update money
            currentMoney -= smoothCost;
            moneyText.GetComponent<Text>().text = "$" + currentMoney.ToString();

            //play sound

            //update player parameters
            currentModel++;
            maxSpeed = 25;
        }
    }

    public void UpgradeToThing2()
    {
        //If player does not have enough money
        if (currentMoney < upgrade2Cost)
        {
            StartCoroutine(ShowNotEnoughMessage());
        }

        //upgrade and set icons
        else
        {
            //set old icon
            upgrade2Button.GetComponent<Button>().interactable = false;
            upgrade2Button.transform.GetChild(1).GetComponent<Text>().text = "Purchased";
            upgrade2Button.transform.GetChild(1).GetComponent<Text>().color = new Color32(59, 255, 0, 255);

            //set next Icon
            upgrade3Button.GetComponent<Button>().interactable = true;
            upgrade3Button.transform.GetChild(1).GetComponent<Text>().text = upgrade3Cost.ToString();
            upgrade3Button.transform.GetChild(1).GetComponent<Text>().color = new Color32(255, 217, 0, 255);

            //update money
            currentMoney -= upgrade2Cost;
            moneyText.GetComponent<Text>().text = "$" + currentMoney.ToString();

            //play sound


            //update player parameters
            ability++;
            currentLabel++;
        }
    }
    public void UpgradeToThing3()
    {
        //If player does not have enough money
        if (currentMoney < upgrade3Cost)
        {
            StartCoroutine(ShowNotEnoughMessage());
        }

        //upgrade and set icons
        else
        {
            //set old icon
            upgrade3Button.GetComponent<Button>().interactable = false;
            upgrade3Button.transform.GetChild(1).GetComponent<Text>().text = "Purchased";
            upgrade3Button.transform.GetChild(1).GetComponent<Text>().color = new Color32(59, 255, 0, 255);

            //update money
            currentMoney -= upgrade3Cost;
            moneyText.GetComponent<Text>().text = "$" + currentMoney.ToString();

            //play sound

            //update player parameters
            ability++;
            currentLabel++;
        }
    }

    
    public void StartRun()
    {
        purchaseUI.SetActive(false);
        SceneManager.LoadScene("Dylan Test");
    }
    
    IEnumerator ShowNotEnoughMessage()
    {
        notEnoughMoneyText.SetActive(true);
        yield return new WaitForSeconds(2);
        notEnoughMoneyText.SetActive(false);
    }
}
