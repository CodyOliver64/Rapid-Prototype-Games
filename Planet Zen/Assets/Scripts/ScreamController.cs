using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamController : MonoBehaviour
{
    public GameObject screamUI;
    public GameObject cliffText;
    public Transform screamBar;

    private bool screamActive;

    private AudioClip audioStream = null;

    public float averageSample = 0;

    private float avg;
    private float[] samples;
    private int length;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }



        audioStream = Microphone.Start("Headset Microphone (Oculus Virtual Audio Device)", true, 3, 44100);

        length = audioStream.samples * audioStream.channels;
        samples = new float[length];

    }

    // Update is called once per frame
    void Update()
    {
        samples = new float[length];
        audioStream.GetData(samples, 0);

        for (int i = 0; i < length; i++)
        {
            avg += samples[i];
        }

        avg = (avg / length) * 10000;

        if (avg > 0)
        {
            averageSample = avg;
            screamBar.localScale = new Vector3(averageSample, 1, 0);
        }
        else
        {
            screamBar.localScale = new Vector3(0, 1, 0);
        }


        if (screamActive)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        screamUI.SetActive(true);
        cliffText.SetActive(true);
        screamActive = true;
        StartCoroutine(waitTime1());
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            return;

        screamUI.SetActive(false);
        screamActive = false;
    }

    IEnumerator waitTime1()
    {

        yield return new WaitForSeconds(6);
        cliffText.SetActive(false);

    }
}
