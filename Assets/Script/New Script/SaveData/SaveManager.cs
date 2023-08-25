using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "playerSave.json");
    }

    public void SavePlayerData(PlayerData data)
    {
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, jsonData);
    }

    public PlayerData LoadPlayerData()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            return JsonUtility.FromJson<PlayerData>(jsonData);
        }
        return new PlayerData();
    }
}
