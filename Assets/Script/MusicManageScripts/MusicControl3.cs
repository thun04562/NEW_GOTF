using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl3 : MonoBehaviour
{
    public static MusicControl3 instance;

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
