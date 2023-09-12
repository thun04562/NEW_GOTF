using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenShop : MonoBehaviour
{
    private bool playerInRange;
    private SpriteRenderer spriteRenderer;
    private string currentSceneName; // To store the name of the current scene
    public PlayerControl playerControl;
    public GameObject shopUI;
    public bool openShop;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Initially, disable the SpriteRenderer


        // Store the name of the current scene
        //currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            // Enable the SpriteRenderer when the player enters the collider
            //spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            // Disable the SpriteRenderer when the player exits the collider
            //spriteRenderer.enabled = false;
        }
    }

    private void Update()
    {
        
        if (playerInRange && Input.GetKeyDown(KeyCode.W) && !openShop)
        {

            shopUI.SetActive(true);
            openShop = true;
            Time.timeScale = 0f;
        }

        else if ( playerInRange && Input.GetKeyDown(KeyCode.W) && openShop)
        {

            shopUI.SetActive(false);
            openShop = false;
            Time.timeScale = 1f;
        }
    }
}
