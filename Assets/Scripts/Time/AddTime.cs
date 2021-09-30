using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Attach to AddTime Text at top of level (DOESN'T EXIST IN FIRST LEVEL)
//Set the amount of time that should be added to the timer for each level
public class AddTime : MonoBehaviour
{
    //number of seconds to be added to the timeRemaining (can be tweaked for each level)
    public float addedTimeLevel = 60f;

    public Text addedTimeText;

    //countdown to disable "addTime" gameObject
    public float addedTimeTextCountdown = 5f;

    //used to update timeRemaining
    private float timeRemaining;
    private float addedTime;

    //for countdown to disable "addedTime" text
    private float countdownTimer;
    //to check levelNumber so "AddTime" only runs once
    private int addTimeLevelNumber;

    void OnEnable()
    {
        //get "addTimeLevelNumber"
        addTimeLevelNumber = PlayerPrefs.GetInt("addTimeLevelNumber");

        //This allows for "AddTime" to only occur once
        if (addTimeLevelNumber == SceneManager.GetActiveScene().buildIndex)
        {
            //update levelNumber (+1)
            PlayerPrefs.SetInt("addTimeLevelNumber", SceneManager.GetActiveScene().buildIndex + 1);

            //get timeRemaining playerpref
            timeRemaining = PlayerPrefs.GetFloat("timeRemaining");
            addedTime = addedTimeLevel;

            //set "AddTime" text
            addedTimeText.text = string.Format("+{0} seconds", addedTime);
            //update "timeRemaining" playerpref
            PlayerPrefs.SetFloat("timeRemaining", timeRemaining + addedTime);

            //countdown to remove "addedTime" text
            countdownTimer = addedTimeTextCountdown;
            InvokeRepeating("CheckTimer", 0f, 1f);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
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
