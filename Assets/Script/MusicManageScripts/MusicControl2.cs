using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl2 : MonoBehaviour
{
    public static MusicControl2 instance;

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
