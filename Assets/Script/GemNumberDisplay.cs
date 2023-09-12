using UnityEngine;
using UnityEngine.UI;

public class GemNumberDisplay : MonoBehaviour
{
    PlayerControl playerControl;
    public Text gemNumberText;

    public void UpdateGemUI()
    {
        
        if (gemNumberText != null)
        {
            gemNumberText.text = playerControl.gemCount.ToString();
        }
    }

    private void Start()
    {
        playerControl = FindObjectOfType<PlayerControl>();
       
    }
    private void Update()
    {
        UpdateGemUI();
    }
}
