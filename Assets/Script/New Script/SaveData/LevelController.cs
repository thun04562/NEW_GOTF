using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int levelIndex; // Set this in the Inspector

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void CompleteLevel()
    {
        gameManager.LevelCompleted(levelIndex);
    }
}
