using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{

    //Time before next scene
    public float timeBeforeNextScene = 5f;
    
    //updating text for level countdown
    public Text nextSceneTimerText;
    
    //set as player
    public GameObject playerObj;

    private int timeLeft;
    private float countdownTimer;
    
    // disable player controller and reset on finish line collision
    // start counting down until next level
    void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Finish")
        {
            playerObj.gameObject.GetComponent<PlayerController>().enabled = false;
            playerObj.gameObject.GetComponent<Reset>().enabled = false;

            countdownTimer = timeBeforeNextScene;
            InvokeRepeating("CheckTimer", 0f, 1f);
        }
    }

    //check countdown until next level
    void CheckTimer ()
    {
        //decrement countdownTimer
        countdownTimer -= 1f;
        SetTimerText();
        if (countdownTimer == 0)
        {
            //when timer hits 0
            CancelInvoke("CheckTimer");
            Invoke("LoadNextLevel", 5f);
        }
    }

    //update text during countdown
    void SetTimerText()
    {
        timeLeft = (int)countdownTimer;
        nextSceneTimerText.text = string.Format("Next Level In... {0}", timeLeft);
    }

    void LoadNextLevel()
    {
        //enable playerController and reset components
        playerObj.gameObject.GetComponent<PlayerController>().enabled = true;
        playerObj.gameObject.GetComponent<Reset>().enabled = true;
        //change to next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
