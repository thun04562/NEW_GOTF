using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SaveManager saveManager;
    private PlayerData playerData;

    private void Start()
    {
        saveManager = GetComponent<SaveManager>();
        playerData = saveManager.LoadPlayerData();
    }

    public void LevelCompleted(int levelIndex)
    {
        if (!playerData.unlockedLevels.Contains(levelIndex))
        {
            playerData.unlockedLevels.Add(levelIndex);
            saveManager.SavePlayerData(playerData);
        }
    }

    public void CollectItem(int itemIndex)
    {
        if (!playerData.collectedItems.Contains(itemIndex))
        {
            playerData.collectedItems.Add(itemIndex);
            saveManager.SavePlayerData(playerData);
        }
    }
}
