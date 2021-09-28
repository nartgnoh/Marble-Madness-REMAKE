using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//Attach to Score Text at top of level
public class EndLevelScore : MonoBehaviour
{
    public Text timeBonusText;
    public Text overallScoreText;

    private double timeBonus;
    private double overallScore;

    void OnEnable()
    {
        //get global timeBonus
        timeBonus = Math.Round(PlayerPrefs.GetFloat("timeBonus"));
        //get global overallScore
        overallScore = Math.Round(PlayerPrefs.GetFloat("overallScore"));

        timeBonusText.text = string.Format("Time Bonus: +{0}", timeBonus);
        overallScoreText.text = string.Format("Overall Score: {0}", overallScore);
    }
}
