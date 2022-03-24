using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void NextScene()
    {
        SceneManager.LoadScene("V7");
    }
}
