using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitGame : MonoBehaviour
{
    
    public void ButtonQuit()
    {
        Application.Quit();

        Debug.Log("quit");
    }

}
