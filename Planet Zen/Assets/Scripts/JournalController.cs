using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class JournalController : MonoBehaviour
{
    public GameObject journal;

    private bool isOpen = false;

    public GameObject[] newDiscoveryIcons;

    public int currentPage = 1;

    [SerializeField] private InputActionReference journalOpenReference;
    [SerializeField] private InputActionReference pageRightReference;
    [SerializeField] private InputActionReference pageLeftReference;


    // Start is called before the first frame update
    void Start()
    {
        journalOpenReference.action.performed += OnJournalOpen;
        pageRightReference.action.performed += OnPageRight;
        pageLeftReference.action.performed += OnPageLeft;
    }

    // Update is called once per frame
    void Update()
    {
        //OpenCloseJournal();
        //ChangePage();
    }

    /*public void OpenCloseJournal()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isOpen)
        {
            Debug.Log("Button worked!");
            journal.SetActive(true);
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            journal.SetActive(false);

            for (int i = 0; i < newDiscoveryIcons.Length; i++)
            {
                newDiscoveryIcons[i].SetActive(false);
            }

            isOpen = false;
        }
    }

    public void ChangePage()
    {
        if (Input.GetKeyDown(KeyCode.R) && isOpen && currentPage < 2)
        {
            journal.transform.GetChild(currentPage).gameObject.SetActive(false);
            currentPage++;
            journal.transform.GetChild(currentPage).gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && isOpen && currentPage > 1)
        {
            journal.transform.GetChild(currentPage).gameObject.SetActive(false);
            currentPage--;
            journal.transform.GetChild(currentPage).gameObject.SetActive(true);
        }

    }*/

    private void OnJournalOpen(InputAction.CallbackContext obj)
    {
        if (!isOpen)
        {
            Debug.Log("Button worked!");
            journal.SetActive(true);
            isOpen = true;
        }
        else
        {
            journal.SetActive(false);

            for (int i = 0; i < newDiscoveryIcons.Length; i++)
            {
                newDiscoveryIcons[i].SetActive(false);
            }

            isOpen = false;
        }
    }

    private void OnPageRight(InputAction.CallbackContext obj)
    {
        if (isOpen && currentPage < 3)
        {
            journal.transform.GetChild(currentPage).gameObject.SetActive(false);
            currentPage++;
            journal.transform.GetChild(currentPage).gameObject.SetActive(true);
        }
    }

    private void OnPageLeft(InputAction.CallbackContext obj)
    {
        if (isOpen && currentPage > 1)
        {
            journal.transform.GetChild(currentPage).gameObject.SetActive(false);
            currentPage--;
            journal.transform.GetChild(currentPage).gameObject.SetActive(true);
        }
    }
}
