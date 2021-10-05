using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Attach to Player
//Player Finish Level functionality - onCollisionEnter a "Finish" tagged "LevelEndMarker"
public class FinishLevel : MonoBehaviour
{
    //Time before next scene
    public float timeBeforeNextLevel = 4f;
    
    //updating text for level countdown
    public Text timeBeforeNextLevelText;
    
    //set as player
    public GameObject playerObj;

    private int timeLeft;
    private float countdownTimer;

    //public GameObject win;
    
    // disable player controller and reset on finish line collision
    // start counting down until next level
    void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Finish")
        {
            playerObj.gameObject.GetComponent<PlayerController>().enabled = false;
            playerObj.gameObject.GetComponent<Reset>().enabled = false;
            //Instantiate(win, transform.position, Quaternion.identity);

            countdownTimer = timeBeforeNextLevel;
            InvokeRepeating("CheckTimer", 0f, 1f);
        }
    }

    //check countdown until next level
    void CheckTimer ()
    {
        //decrement countdownTimer
        countdownTimer -= 1f;
        SetTimerText();
        if (countdownTimer == 1)
        {
            //when timer hits 1
            CancelInvoke("CheckTimer");
            Invoke("LoadNextLevel", 5f);
        }
    }

    //update text during countdown
    void SetTimerText()
    {
        //(total number of scenes - 3) to get the number of the final level
        if (SceneManager.sceneCountInBuildSettings-3 == SceneManager.GetActiveScene().buildIndex)
        {   
            timeLeft = (int)countdownTimer;
            timeBeforeNextLevelText.text = string.Format("Success!");
        }
        else
        {
            timeLeft = (int)countdownTimer;
            timeBeforeNextLevelText.text = string.Format("Next Level In... {0}", timeLeft);
        }
    }

    void LoadNextLevel()
    {
        //enable playerController and reset components
        playerObj.gameObject.GetComponent<PlayerController>().enabled = true;
        playerObj.gameObject.GetComponent<Reset>().enabled = true;

        //(total number of scenes - 3) to get the number of the final level
        if (SceneManager.sceneCountInBuildSettings-3 == SceneManager.GetActiveScene().buildIndex)
        {
            //change to success scene
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        }
        else
        {
            //change to next level scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
