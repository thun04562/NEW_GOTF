using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPauseLoadingScene : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Loading")
            MusicControlStart.instance.GetComponent<AudioSource>().Pause();
    }
}
