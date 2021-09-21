using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //float to count time
    public float timeRemaining = 60.0f;

    //text for timer
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        //count down
        if(timeRemaining>0)
        {
            timeRemaining -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        else
        {
            //lose end scene
        }
    }
}
