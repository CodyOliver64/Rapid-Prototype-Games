using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathBarController : MonoBehaviour
{
    public GameObject breathUI;
    public Transform breathIn;
    public Transform breathOut;
    public Transform holdBreath;

    public GameObject breatheInText;
    public GameObject breatheOutText;
    public GameObject holdBreathText;

    private float inProgress = 0f;
    private float outProgress = 1f;
    private float holdProgress = 0f;

    public float counter = 1;

    public int timeBetweenBreath = 15;

    public bool breathActive = false;
    public bool timerActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInBar();
        UpdateHoldBar();
        UpdateOutBar();

        if (timerActive)
            counter += Time.deltaTime;
        if (Mathf.Round(counter) % timeBetweenBreath == 0)
            ActivateBreathingExercise();

    }

    private void UpdateInBar()
    {
        if (inProgress >= 1)
            return;
        if (!breathActive)
            return;

        breatheInText.SetActive(true);
        inProgress += .25f * Time.deltaTime;
        breathIn.localScale += new Vector3(0, .25f * Time.deltaTime, 0);
    }

    private void UpdateHoldBar()
    {
        if (inProgress <= 1)
            return;
        if (!breathActive)
            return;
        if (holdProgress >= 1)
            return;

        breatheInText.SetActive(false);
        holdBreathText.SetActive(true);

        holdProgress += .25f * Time.deltaTime;
        holdBreath.localScale += new Vector3(.25f * Time.deltaTime, 0, 0);
    }

    private void UpdateOutBar()
    {
        if (holdProgress <= 1)
            return;
        if (!breathActive)
            return;
        if (outProgress <= 0)
        {
            breathUI.SetActive(false);
            breathActive = false;
            breatheOutText.SetActive(false);
            counter = 1f;
            return;
        }

        holdBreathText.SetActive(false);
        breatheOutText.SetActive(true);

        outProgress -= .25f * Time.deltaTime;
        breathOut.localScale -= new Vector3(0, .25f * Time.deltaTime, 0);
    }

    private void ActivateBreathingExercise()
    {
        if (breathActive == true)
            return;
        
        inProgress = 0f;
        holdProgress = 0f;
        outProgress = 1f;

        breathIn.localScale = new Vector3(1, 0, 1);
        holdBreath.localScale = new Vector3(0, 1, 1);
        breathOut.localScale = new Vector3(1, 1, 1);

        breathUI.SetActive(true);
        breathActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;
        
        timerActive = true;
        ActivateBreathingExercise();

        Debug.Log("trigger is:" + other.gameObject.name);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            return;

        counter = 1f;
        timerActive = false;
    }

    IEnumerator waitTime()
    {

        yield return new WaitForSeconds(1);

    }

}
