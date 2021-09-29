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
    private bool isPaused = false;
    PauseAction action;

    // public GameObject pauseMenuUI;

    // Update is called once per frame

    private void Awake()
    {
        action = new PauseAction();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.Pause.PauseGame.performed += _ => DeterminePause();
    }

    private void DeterminePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
       // GameIsPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Home(int sceneID)
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
