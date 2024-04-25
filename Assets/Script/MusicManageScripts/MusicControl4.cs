using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl4 : MonoBehaviour
{
    public static MusicControl4 instance;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
