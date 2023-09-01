using UnityEngine;
using UnityEngine.UI;

public class GemNumberDisplay : MonoBehaviour
{
    public Text gemNumberText;

    private void Start()
    {
        // Find the PlayerControl script's GameObject and get the component
        PlayerControl playerControl = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();

        // Access the gemCount variable from the PlayerControl script
        int gemCount = playerControl.gemCount;

        // Optionally, display the gemCount in the UI Text component
        if (gemNumberText != null)
        {
            gemNumberText.text = gemCount.ToString();
        }
    }
}
