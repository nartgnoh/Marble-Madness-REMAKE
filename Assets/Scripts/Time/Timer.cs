using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//Attach to Timer Text at top of level
public class Timer : MonoBehaviour
{
    //float to count time
    public float initialTime = 60.0f;

    //text for timer
    public Text timerText;

    private float timeRemaining;

    void Start()
    {
        timeRemaining = PlayerPrefs.GetFloat("timeRemaining", timeRemaining);
    }

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
            PlayerPrefs.SetFloat("timeRemaining", timeRemaining);
        }
        else
        {
            //lose end scene
        }
    }

    void Awake()
    {
        //don't destroy object on scene load
        DontDestroyOnLoad(this.gameObject);
        timeRemaining = initialTime;
    }
}
