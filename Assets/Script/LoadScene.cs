using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public string SceneName;
    public void NextScene(string SceneName)
    {
        //SoundManager.PlaySound("Button");
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1f;
        PlayerPrefs.DeleteAll();
    }

}
