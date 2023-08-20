using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlStart : MonoBehaviour
{
    public static MusicControlStart instance;

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
