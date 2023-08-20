using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        //SoundManager.PlaySound("UI0");
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
