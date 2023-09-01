using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{
    public static int playerHealth = 3;
    public Sprite fullHeart, emptyHeart;
    public Image[] hearts;
    

    private void Awake()
    {
        playerHealth = 3;
    }

    public void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < playerHealth; i++)
        { 
            hearts[i].sprite = fullHeart;

        }
        
    }

    

}

