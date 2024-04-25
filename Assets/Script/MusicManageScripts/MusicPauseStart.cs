using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPauseStart : MonoBehaviour
{
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/

        if (SceneManager.GetActiveScene().name == "Start")
            MusicControl3.instance.GetComponent<AudioSource>().Pause();
    }
}
