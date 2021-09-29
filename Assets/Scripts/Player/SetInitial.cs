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
        PlayerPrefs.SetInt("levelNumber", SceneManager.GetActiveScene().buildIndex);
    }

    void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Finish")
        {
            PlayerPrefs.SetInt("levelNumber", SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
