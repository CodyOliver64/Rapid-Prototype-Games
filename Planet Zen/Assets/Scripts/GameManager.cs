using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float timePassed;
    private int secondsPassed;
    public int minutesPassed;
    private int hoursPassed;
    private string timeString;

    void Start()
    {
        
    }

    void Update()
    {
        StopWatch();
    }

    private void StopWatch()
    {
        // Overall time passed in seconds
        timePassed += Time.deltaTime;

        // Seconds
        secondsPassed = (int) timePassed % 60;

        // Minutes
        minutesPassed = (int)timePassed / 60;
        minutesPassed %= 60;

        // Hours
        hoursPassed = (int)timePassed / 3600;

        // Stopwatch string
        timeString = $"{hoursPassed}:{minutesPassed}:{secondsPassed}";

        Debug.Log(timeString);
    }
}
