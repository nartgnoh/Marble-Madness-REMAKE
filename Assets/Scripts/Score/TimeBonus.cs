using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//CURRENTLY NOT IN USE - timebonus logic can be found in the "levelend" that triggers on "levelendmarker" collision

//Attach to gameObject
public class TimeBonus : MonoBehaviour
{
    private double timeRemaining;
    private float timeBonus;
    private float overallScore;

    //enters end marker
    void OnEnable()
    {
        //get global timeRemaining
        timeRemaining = Math.Round(PlayerPrefs.GetFloat("timeRemaining"), 0);
        //calculate time bonus and set global
        timeBonus = (float)timeRemaining * 1000;
        PlayerPrefs.SetFloat("timeBonus", timeBonus);
        //get global overallScore
        overallScore = PlayerPrefs.GetFloat("overallScore");

        //update global "overallScore" with overallScore+timeBonus
        PlayerPrefs.SetFloat("overallScore", overallScore + timeBonus);
    }
}
