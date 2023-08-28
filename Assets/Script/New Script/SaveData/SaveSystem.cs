using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveSystem : MonoBehaviour
{
    public string playerHealthKey = "PlayerHealth", sceneKey = "SceneIndex", savePresenKey = "SavePresent";

    public LoadedData LoadedData{ get; private set; }

    public UnityEvent<bool> OnDataLoadedResult;
 

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

        var result = LoadData();
        OnDataLoadedResult?.Invoke(result);

    }

    public void ResetData()
    {
        PlayerPrefs.DeleteKey(playerHealthKey);
        PlayerPrefs.DeleteKey(sceneKey);
        PlayerPrefs.DeleteKey(savePresenKey);
        LoadedData = null;
    }

    public bool LoadData()
    {
        if (PlayerPrefs.GetInt(savePresenKey) == 1)
        {
            LoadedData = new LoadedData();
            LoadedData.playerHealth = PlayerPrefs.GetInt(playerHealthKey);
            LoadedData.sceneIndes = PlayerPrefs.GetInt(sceneKey);
            return true;
        }
        return false;
    }

    public void SaveData(int sceneIndex, int playerHealth)
    {
        if(LoadedData == null)
            LoadedData = new LoadedData();
        LoadedData.playerHealth = playerHealth;
        LoadedData.sceneIndes = sceneIndex;
        PlayerPrefs.SetInt(playerHealthKey, playerHealth);
        PlayerPrefs.SetInt(sceneKey, sceneIndex);
        PlayerPrefs.SetInt(savePresenKey, 1);
    }
}

public class LoadedData
{
    public int playerHealth = -1;
    public int sceneIndes = -1;

}

