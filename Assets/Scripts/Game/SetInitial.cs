using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Attach to empty game object in Start Menu
public class SetInitial : MonoBehaviour
{
    // Setting initial PlayerPrefs
    void Start()
    {
        PlayerPrefs.DeleteAll();
        //Set totalTimeBonus = 0 at start
        PlayerPrefs.SetFloat("totalTimeBonus", 0f);
        //Set addTimeLevelNumber = 2 to start so "AddTime" only occurs on level 2 and onwards
        PlayerPrefs.SetInt("addTimeLevelNumber", SceneManager.GetActiveScene().buildIndex + 2);
        //Set levelEndNumber = 1 to start so "LevelEnd" "OnCollisionEnter" only occurs once
        PlayerPrefs.SetInt("levelEndNumber", SceneManager.GetActiveScene().buildIndex + 1);
        //Set playerLevelEndNumber = 1 to start so Player's "FinishLevel" "OnCollisionEnter" only occurs once
        PlayerPrefs.SetInt("playerLevelEndNumber", SceneManager.GetActiveScene().buildIndex + 1);
    }
}
