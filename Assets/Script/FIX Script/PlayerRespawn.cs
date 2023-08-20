using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRespawn : MonoBehaviour
{
    public Transform respawnPoint; // The transform representing the respawn point
    public float respawnTime = 2f; // The time in seconds before respawning

    private Vector3 initialPosition;
    private bool isRespawning = false;

    private void Start()
    {
        initialPosition = transform.position; // Store the initial position as the respawn point
    }

    private void Update()
    {
        // Add your own input handling here to trigger respawning if needed
        if (isRespawning)
        {
            // Handle respawning countdown
            respawnTime -= Time.deltaTime;
            if (respawnTime <= 0f)
            {
                Respawn();
            }
        }
    }

    public void Respawn()
    {
        // Reset respawn timer and flag
        respawnTime = 2f;
        isRespawning = false;

        // Move the player to the respawn point
        transform.position = respawnPoint.position;

        // Add any additional respawn logic here, such as restoring health

        // Enable player controls or input handling again
        // Example: GetComponent<PlayerController>().enabled = true;
    }

    public void StartRespawn()
    {
        // Disable player controls or input handling while respawning
        // Example: GetComponent<PlayerController>().enabled = false;

        isRespawning = true;
    }

    // Call this function to set a new respawn point (e.g., upon reaching a checkpoint)
    public void SetRespawnPoint(Transform newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }
}


/*public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip CheckpointSound;
    private Transform currentCheckpoint;
    private PlayerHealthManager playerHealth;
    public ParallaxMoveBG parallaxScrolling;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealthManager>();
    }

    public void Respawn()
    {
        // Pause parallax scrolling during respawn
        parallaxScrolling.enabled = false;

        playerHealth.Respawn();
        transform.position = currentCheckpoint.position;
        
        // Move parallax layers back to their initial positions
        //parallaxScrolling.ResetParallaxLayers();

        // Resume parallax scrolling after respawn
        parallaxScrolling.enabled = true;

        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            SoundManager.instance.PlaySound(CheckpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("save");
        }
    }

}*/
