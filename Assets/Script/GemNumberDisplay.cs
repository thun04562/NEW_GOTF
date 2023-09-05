using UnityEngine;
using UnityEngine.UI;

public class GemNumberDisplay : MonoBehaviour
{
    public Text gemNumberText;

    public void UpdateGemUI()
    {
        int gemCount = PlayerPrefs.GetInt("GemCount");
        if (gemNumberText != null)
        {
            gemNumberText.text = gemCount.ToString();
        }
    }

    private void Start()
    {
        UpdateGemUI();
    }
}
