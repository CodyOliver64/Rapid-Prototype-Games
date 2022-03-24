using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractableW1 : MonoBehaviour
{
    public float radius = 3f;

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

    public Interactable0 mainBowl;



    private void Start()
    {
        
    }

    private void Update()
    {
        if (isInRange1)
        {
            if (Input.GetKeyDown(getIceCreamKey1))
            {
                iceCreamAction1.Invoke();

            }
        }

        if (isInRange2)
        {
            if (Input.GetKeyDown(getIceCreamKey2))
            {
                iceCreamAction2.Invoke();
            }
        }

        if (isInRange3)
        {
            if (Input.GetKeyDown(getIceCreamKey3))
            {
                iceCreamAction3.Invoke();
            }
        }

        if (isInRange4)
        {
            if (Input.GetKeyDown(getIceCreamKey4))
            {
                iceCreamAction4.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sophie" && mainBowl.P1Score == 5)
        {
            isInRange1 = true;
            other.transform.GetChild(5).gameObject.SetActive(true);
        }

        if (other.gameObject.name == "Charlie" && mainBowl.P2Score == 5)
        {
            isInRange2 = true;
            other.transform.GetChild(4).gameObject.SetActive(true);
        }

        if (other.gameObject.name == "Valli" && mainBowl.P3Score == 5)
        {
            isInRange3 = true;
            other.transform.GetChild(4).gameObject.SetActive(true);
        }

        if (other.gameObject.name == "Patrick" && mainBowl.P4Score == 5)
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







}
