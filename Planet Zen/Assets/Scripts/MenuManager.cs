using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject resourcesPanel;

    private bool isOpen;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null); // Remove any selection
        EventSystem.current.SetSelectedGameObject(startButton); // Select New Game at start
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Terrain Building");
    }

    public void ResourcesScreen()
    {
        if (!isOpen)
        {
            EventSystem.current.SetSelectedGameObject(null); // Remove any selection
            isOpen = true;
            resourcesPanel.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(backButton);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null); // Remove any selection
            isOpen = false;
            resourcesPanel.gameObject.SetActive(false);
            EventSystem.current.SetSelectedGameObject(startButton);
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif

    }
}
