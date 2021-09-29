using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Attach to Timer Text at top of level
//Set the number of levels AFTER first level
//Set the amount of time that should be added to the timer for each level
public class AddTime : MonoBehaviour
{
    public float addedTimeLevel;

    public Text addedTimeText;

    public float addedTimeTextCountdown = 5f;

    private float timeRemaining;
    private float addedTime;

    //for countdown to disable "addedTime" text
    private float countdownTimer;

    void OnEnable()
    {
        timeRemaining = PlayerPrefs.GetFloat("timeRemaining");

        addedTime = addedTimeLevel;

        addedTimeText.text = string.Format("+{0} seconds", addedTime);
        //update "timeRemaining" playerpref
        PlayerPrefs.SetFloat("timeRemaining", timeRemaining + addedTime);

        //countdown to remove "addedTime" text
        countdownTimer = addedTimeTextCountdown;
        InvokeRepeating("CheckTimer", 0f, 1f);
    }

    //countdown to remove "addedTime" text
    void CheckTimer ()
    {
        countdownTimer -= 1f;
        if (countdownTimer == 0)
        {
            //when timer hits 0
            CancelInvoke("CheckTimer");
            this.gameObject.SetActive(false);
        }
    }
}
