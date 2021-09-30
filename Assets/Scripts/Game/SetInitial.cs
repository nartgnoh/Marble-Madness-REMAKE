using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Attach to Player for FIRST LEVEL ONLY
public class SetInitial : MonoBehaviour
{
    // Setting initial PlayerPrefs
    void Start()
    {
        //Start "addTime" on second level
        PlayerPrefs.SetInt("levelNumber", 2);
        //Set totalTimeBonus = 0 at start
        PlayerPrefs.SetFloat("totalTimeBonus", 0f);
    }
}
