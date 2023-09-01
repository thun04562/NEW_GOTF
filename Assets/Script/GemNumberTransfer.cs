using UnityEngine;
using UnityEngine.SceneManagement;

public class GemNumberTransfer : MonoBehaviour
{
    public int gemNumberToTransfer = 100; // Replace with your actual GemNumber value

    private void Start()
    {
        // Save GemNumber to PlayerPrefs when the scene starts
        PlayerPrefs.SetInt("GemNumber", gemNumberToTransfer);
        PlayerPrefs.Save();
    }

    // Add any other relevant logic to your script as needed
}
