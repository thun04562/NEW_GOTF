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

    public void ReturnToGameplayScene()
    {
        // Call ClearGemCountIfReturningToGameplay1 before restarting the scene.
        FindObjectOfType<PlayerControl>().ClearGemCountIfReturningToGameplay1();

        // This method returns to the gameplay scene specified in the SceneName variable.
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }
}
