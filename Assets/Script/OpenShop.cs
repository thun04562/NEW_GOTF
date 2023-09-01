using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenShop : MonoBehaviour
{
    private bool playerInRange = false;
    private SpriteRenderer spriteRenderer;
    private string currentSceneName; // To store the name of the current scene



    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Initially, disable the SpriteRenderer
        spriteRenderer.enabled = false;

        // Store the name of the current scene
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            // Enable the SpriteRenderer when the player enters the collider
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            // Disable the SpriteRenderer when the player exits the collider
            spriteRenderer.enabled = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Check if the shop is already open
            Scene skillShopScene = SceneManager.GetSceneByName("SkillShop");
            if (!skillShopScene.isLoaded)
            {
                // Load the "SkillShop" scene additively, so the current scene is not restarted
                SceneManager.LoadScene("SkillShop", LoadSceneMode.Additive);
                Time.timeScale = 0f;
            }
        }

        if (currentSceneName != "SkillShop" && Input.GetKeyDown(KeyCode.E))
        {
            // Unload the "SkillShop" scene if it's loaded and we are not in the "SkillShop" scene
            Scene skillShopScene = SceneManager.GetSceneByName("SkillShop");
            if (skillShopScene.isLoaded)
            {
                SceneManager.UnloadScene("SkillShop");
                Time.timeScale = 1f;
            }
        }
    }
}
