using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerRespawnWithUI : MonoBehaviour
{
    public Transform respawnPoint; // The transform representing the respawn point
    public float respawnTime = 2f; // The time in seconds before respawning
    public GameObject deathUI; // The UI panel to show upon death

    private Vector3 initialPosition;
    private bool isRespawning = false;

    private Text respawnTimeText;
    private Button respawnButton;
    private Button mainMenuButton;

    private void Start()
    {
        initialPosition = transform.position; // Store the initial position as the respawn point

        // Find the UI elements
        respawnTimeText = deathUI.transform.Find("RespawnTimeText").GetComponent<Text>();
        respawnButton = deathUI.transform.Find("RespawnButton").GetComponent<Button>();
        mainMenuButton = deathUI.transform.Find("MainMenuButton").GetComponent<Button>();

        // Add button click listeners
        respawnButton.onClick.AddListener(StartRespawn);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);

        // Hide the death UI initially
        deathUI.SetActive(false);
    }

    private void Update()
    {
        // Add your own input handling here to trigger respawning if needed
        if (isRespawning)
        {
            // Handle respawning countdown
            respawnTime -= Time.deltaTime;
            respawnTimeText.text = Mathf.CeilToInt(respawnTime).ToString();

            if (respawnTime <= 0f)
            {
                Respawn();
            }
        }
    }

    public void StartRespawn()
    {
        // Disable player controls or input handling while respawning
        // Example: GetComponent<PlayerController>().enabled = false;

        isRespawning = true;
        deathUI.SetActive(false); // Hide the death UI
    }

    public void Respawn()
    {
        // Reset respawn timer and flag
        respawnTime = 2f;
        isRespawning = false;

        // Move the player to the respawn point
        transform.position = respawnPoint.position;

        // Enable player controls or input handling again
        // Example: GetComponent<PlayerController>().enabled = true;
    }

    public void ShowDeathUI()
    {
        deathUI.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Change "MainMenu" to your actual scene name
    }

    // Call this function to set a new respawn point (e.g., upon reaching a checkpoint)
    public void SetRespawnPoint(Transform newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }
}
