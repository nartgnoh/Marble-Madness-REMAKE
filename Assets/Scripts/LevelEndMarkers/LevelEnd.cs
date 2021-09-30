using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Attach to LevelEndMarker(s)
public class LevelEnd : MonoBehaviour
{
    //end screen Canvas
    public GameObject levelEndScreen;
    //to Destroy
    public GameObject timeText;
    public GameObject scoreText;
    //quad marker
    public GameObject endMarker;

    //for time bonus function
    private double timeRemaining;
    private float timeBonus;
    private float currentTotalTimeBonus;
    private float overallScore;

    // Start is called before the first frame update
    void Start()
    {
        //set active false at start
        levelEndScreen.SetActive(false);
    }

    //enters end marker
    void OnCollisionEnter(Collision collision)
    {
        //if collision with player, canvas shows
        if (collision.gameObject.tag == "Player")
        {
            TimePointBonus();
            ResetLevel();

            levelEndScreen.SetActive(true);
        }
    }

    //add timebonus on end level collision
    private void TimePointBonus()
    {
        //get global timeRemaining
        timeRemaining = Math.Round(PlayerPrefs.GetFloat("timeRemaining"), 0);
        //calculate time bonus and set global
        timeBonus = (float)timeRemaining * 1000;
        PlayerPrefs.SetFloat("timeBonus", timeBonus);
        //update totalTimeBonus
        currentTotalTimeBonus = PlayerPrefs.GetFloat("totalTimeBonus");
        PlayerPrefs.SetFloat("totalTimeBonus", currentTotalTimeBonus+timeBonus);
        //get global overallScore
        overallScore = PlayerPrefs.GetFloat("overallScore");

        //update global "overallScore" with overallScore+timeBonus
        PlayerPrefs.SetFloat("overallScore", overallScore + timeBonus);
    }
    
    private void ResetLevel()
    {
        //delete Texts
        Destroy(scoreText);
        Destroy(timeText);
    }
}
