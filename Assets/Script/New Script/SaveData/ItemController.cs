using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int itemIndex; // Set this in the Inspector

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void CollectItem()
    {
        gameManager.CollectItem(itemIndex);
    }
}

