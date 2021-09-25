using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
   // public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // public GameObject pauseMenuUI;

    // Update is called once per frame

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }


    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
       // GameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
