using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Attach to Timer Text at top of level
//Set the number of levels AFTER first level
//Set the amount of time that should be added to the timer for each level
public class AddTime : MonoBehaviour
{
    public float [] addedTimeForNextLevel;
    public int numberOfScenesBeforeNext = 2;

    private float timeRemaining;
    private float addedTime;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        timeRemaining = PlayerPrefs.GetFloat("timeRemaining");
        //look through array to element "activeScene" - numberOfScenesBeforeNext (2)
        //(example; if the scene loaded is 2, 2-2 to get element 0 or "first element" in array)
        addedTime = addedTimeForNextLevel[SceneManager.GetActiveScene().buildIndex - numberOfScenesBeforeNext];

        //update "timeRemaining" playerpref
        PlayerPrefs.SetFloat("timeRemaining", timeRemaining + addedTime);
    }
}
