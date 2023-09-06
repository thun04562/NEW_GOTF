using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private bool hasTriggered = false; // Add a flag to track if it has been triggered
    [SerializeField] private AudioClip CheckpointSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasTriggered) // Check if it's the player and not triggered yet
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            hasTriggered = true; // Set the flag to true to indicate it has been triggered
            SoundManager.instance.PlaySound(CheckpointSound);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hasTriggered) // Check if it's the player and was triggered
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
