using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public string SceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }*/

            if (pauseMenuUI.activeInHierarchy)
                Pause(false);
            else
                Pause(true);
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause(bool status)
    {
        /*pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;*/

        pauseMenuUI.SetActive(status);

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Restert1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay1");
    }

    public void Restert2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay2");
    }

    public void Restert3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay3");
    }
}
