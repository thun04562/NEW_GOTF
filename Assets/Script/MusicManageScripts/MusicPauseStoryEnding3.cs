using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPauseStoryEnding3 : MonoBehaviour
{
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/

        if (SceneManager.GetActiveScene().name == "StoryEnding 3")
            MusicControl4.instance.GetComponent<AudioSource>().Pause();
    }
}
