using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPauseStory7 : MonoBehaviour
{
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/

        if (SceneManager.GetActiveScene().name == "Story 7")
            MusicControl2.instance.GetComponent<AudioSource>().Pause();
    }
}
