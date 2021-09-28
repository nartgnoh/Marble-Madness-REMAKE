using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//Attach to Score Text at top of level
public class Score : MonoBehaviour
{
    //get "pointAdded" many points every "perSecond" seconds
    public float perSecond = 1f;
    public float pointsAdded = 10;

    //text for score
    public Text scoreText;

    //for PlayerPref settings
    private float overallScore;

    void Start() 
    {
        overallScore = PlayerPrefs.GetFloat("overallScore", overallScore);
        // Invokes Points() every "perSecond" (initial case; 5 seconds)
        InvokeRepeating("Points", 0f, perSecond);
    }

    void Points() 
    {
        // Get current "overallScore"
        overallScore = PlayerPrefs.GetFloat("overallScore", overallScore);
        // Add to score
        overallScore += pointsAdded;
        // Set new "overallScore"
        PlayerPrefs.SetFloat("overallScore", overallScore);
    }

    void Update()
    {
        // Get current "overallScore"
        overallScore = PlayerPrefs.GetFloat("overallScore", overallScore);
        // Set "Score" text
        scoreText.text = string.Format("{0}", overallScore);
    }

    void Awake()
    {
        //don't destroy object on scene load
        DontDestroyOnLoad(this.gameObject);
        //initial score
        overallScore = 0;
    }
}
