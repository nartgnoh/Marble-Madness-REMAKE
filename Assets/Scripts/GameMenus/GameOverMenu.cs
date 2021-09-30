using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Attach to Canvas->Score game object in "GameOver" scene and set Texts (game objects)
public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI totalTimeBonusInputField;
    public TextMeshProUGUI otherPointsInputField;
    public TextMeshProUGUI finalScoreInputField;

    private float totalTimeBonus;
    private float finalScore;

    void Awake()
    {
        //get old PlayerPrefs
        totalTimeBonus = PlayerPrefs.GetFloat("totalTimeBonus");
        finalScore = PlayerPrefs.GetFloat("overallScore");

        //Delete all PlayerPrefs so they don't linger
        PlayerPrefs.DeleteAll();

        //set Text input fields
        totalTimeBonusInputField.text = string.Format("+{0}", totalTimeBonus);
        otherPointsInputField.text = string.Format("+{0}", finalScore-totalTimeBonus);
        finalScoreInputField.text = string.Format("{0}", finalScore);
    }
}
