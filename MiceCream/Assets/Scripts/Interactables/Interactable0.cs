using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactable0 : MonoBehaviour
{
    public float radius = 3f;

    public bool gameOver = false;
    
    public bool isInRange1;
    public bool isInRange2;
    public bool isInRange3;
    public bool isInRange4;

    public KeyCode getIceCreamKey1;
    public KeyCode getIceCreamKey2;
    public KeyCode getIceCreamKey3;
    public KeyCode getIceCreamKey4;

    public UnityEvent iceCreamAction1;
    public UnityEvent iceCreamAction2;
    public UnityEvent iceCreamAction3;
    public UnityEvent iceCreamAction4;

    public GameObject strawScoop;
    public GameObject chocScoop;
    public GameObject vanScoop;
    public GameObject pistScoop;

    public GameObject strawWhip;
    public GameObject chocWhip;
    public GameObject vanWhip;
    public GameObject pistWhip;

    public GameObject strawWin;
    public GameObject chocWin;
    public GameObject vanWin;
    public GameObject pistWin;

    public int P1Score = 0;
    public int P2Score = 0;
    public int P3Score = 0;
    public int P4Score = 0;

    public Canvas canvas;

    public AudioSource soundPlayer;
    public AudioClip gameOverSound;



    private void Start()
    {
        
    }

    private void Update()
    {
        if (P1Score == 7 || P2Score == 7 || P3Score == 7 || P2Score == 7)
        {
            ResultsScreen();
        }
        
        if (isInRange1)
        {
            if (Input.GetKeyDown(getIceCreamKey1))
            {
                iceCreamAction1.Invoke();
                P1Score++;
                updateStrawUI();
                isInRange1 = false;
            }
        }

        if (isInRange2)
        {
            if (Input.GetKeyDown(getIceCreamKey2))
            {
                iceCreamAction2.Invoke();
                P2Score++;
                updateChocUI();
                isInRange2 = false;
            }
        }

        if (isInRange3)
        {
            if (Input.GetKeyDown(getIceCreamKey3))
            {
                iceCreamAction3.Invoke();
                P3Score++;
                updateVanUI();
                isInRange3 = false;
            }
        }

        if (isInRange4)
        {
            if (Input.GetKeyDown(getIceCreamKey4))
            {
                iceCreamAction4.Invoke();
                P4Score++;
                updatePisUI();
                isInRange4 = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sophie" && other.GetComponent<HoldingStuff>().isHolding == true)
        {
            isInRange1 = true;
            other.transform.GetChild(5).gameObject.SetActive(true);
        }

        if (other.gameObject.name == "Charlie" && other.GetComponent<HoldingStuff>().isHolding == true)
        {
            isInRange2 = true;
            other.transform.GetChild(4).gameObject.SetActive(true);
        }

        if (other.gameObject.name == "Valli" && other.GetComponent<HoldingStuff>().isHolding == true)
        {
            isInRange3 = true;
            other.transform.GetChild(4).gameObject.SetActive(true);
        }

        if (other.gameObject.name == "Patrick" && other.GetComponent<HoldingStuff>().isHolding == true)
        {
            isInRange4 = true;
            other.transform.GetChild(4).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Sophie")
        {
            isInRange1 = false;
            other.transform.GetChild(5).gameObject.SetActive(false);
        }

        if (other.gameObject.name == "Charlie")
        {
            isInRange2 = false;
            other.transform.GetChild(4).gameObject.SetActive(false);
        }

        if (other.gameObject.name == "Valli")
        {
            isInRange3 = false;
            other.transform.GetChild(4).gameObject.SetActive(false);
        }

        if (other.gameObject.name == "Patrick")
        {
            isInRange4 = false;
            other.transform.GetChild(4).gameObject.SetActive(false);
        }
    }

    public void ResultsScreen()
    {
        if (gameOver)
            return;

        gameOver = true;

        soundPlayer.PlayOneShot(gameOverSound);

        if (P1Score >= 5)
        {
            strawWin.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            strawWin.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (P2Score >= 5)
        {
            chocWin.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            chocWin.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (P3Score >= 5)
        {
            vanWin.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            vanWin.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (P4Score >= 5)
        {
            pistWin.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            pistWin.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void updateStrawUI()
    {
        if (P1Score == 1)
            strawScoop.transform.GetChild(0).gameObject.SetActive(true);
        if (P1Score == 2)
            strawScoop.transform.GetChild(1).gameObject.SetActive(true);
        if (P1Score == 3)
            strawScoop.transform.GetChild(2).gameObject.SetActive(true);
        if (P1Score == 4)
            strawScoop.transform.GetChild(3).gameObject.SetActive(true);
        if (P1Score == 5)
            strawScoop.transform.GetChild(4).gameObject.SetActive(true);
        if (P1Score == 6)
        {
            strawWhip.transform.GetChild(0).gameObject.SetActive(true);
            canvas.transform.GetChild(7).gameObject.SetActive(true);
        }
        if (P1Score == 7)
        {
            strawWhip.transform.GetChild(1).gameObject.SetActive(true);
            canvas.transform.GetChild(8).gameObject.SetActive(true);
        }

    }

    public void updateChocUI()
    {
        if (P2Score == 1)
            chocScoop.transform.GetChild(0).gameObject.SetActive(true);
        if (P2Score == 2)
            chocScoop.transform.GetChild(1).gameObject.SetActive(true);
        if (P2Score == 3)
            chocScoop.transform.GetChild(2).gameObject.SetActive(true);
        if (P2Score == 4)
            chocScoop.transform.GetChild(3).gameObject.SetActive(true);
        if (P2Score == 5)
            chocScoop.transform.GetChild(4).gameObject.SetActive(true);
        if (P2Score == 6)
        {
            chocWhip.transform.GetChild(0).gameObject.SetActive(true);
            canvas.transform.GetChild(7).gameObject.SetActive(true);
        }
        if (P2Score == 7)
        {
            chocWhip.transform.GetChild(1).gameObject.SetActive(true);
            canvas.transform.GetChild(8).gameObject.SetActive(true);
        }

    }
    public void updateVanUI()
    {
        if (P3Score == 1)
            vanScoop.transform.GetChild(0).gameObject.SetActive(true);
        if (P3Score == 2)
            vanScoop.transform.GetChild(1).gameObject.SetActive(true);
        if (P3Score == 3)
            vanScoop.transform.GetChild(2).gameObject.SetActive(true);
        if (P3Score == 4)
            vanScoop.transform.GetChild(3).gameObject.SetActive(true);
        if (P3Score == 5)
            vanScoop.transform.GetChild(4).gameObject.SetActive(true);
        if (P3Score == 6)
        {
            vanWhip.transform.GetChild(0).gameObject.SetActive(true);
            canvas.transform.GetChild(7).gameObject.SetActive(true);
        }
        if (P3Score == 7)
        {
            vanWhip.transform.GetChild(1).gameObject.SetActive(true);
            canvas.transform.GetChild(8).gameObject.SetActive(true);
        }

    }

    public void updatePisUI()
    {
        if (P4Score == 1)
            pistScoop.transform.GetChild(0).gameObject.SetActive(true);
        if (P4Score == 2)
            pistScoop.transform.GetChild(1).gameObject.SetActive(true);
        if (P4Score == 3)
            pistScoop.transform.GetChild(2).gameObject.SetActive(true);
        if (P4Score == 4)
            pistScoop.transform.GetChild(3).gameObject.SetActive(true);
        if (P4Score == 5)
            pistScoop.transform.GetChild(4).gameObject.SetActive(true);
        if (P4Score == 6)
        {
            pistWhip.transform.GetChild(0).gameObject.SetActive(true);
            canvas.transform.GetChild(7).gameObject.SetActive(true);
        }
        if (P4Score == 7)
        {
            pistWhip.transform.GetChild(1).gameObject.SetActive(true);
            canvas.transform.GetChild(8).gameObject.SetActive(true);
        }

    }







}
