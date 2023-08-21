using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGem : MonoBehaviour
{
    private bool openAllowed;
    public Animator animator;
    public GameObject gemPrefab;
    public float bounceForce = 10.0f;
    public int numberOfGemsToSpawn = 3;

    private int gemsCollected = 0;

    void Update()
    {
        if (openAllowed && Input.GetKeyDown(KeyCode.E))
            OpenChest();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            openAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            openAllowed = false;
        }
    }

    private void OpenChest()
    {
        animator.SetTrigger("EmptyChest");
        GetComponent<Collider2D>().enabled = false;

        for (int i = 0; i < numberOfGemsToSpawn; i++)
        {
            GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity);
            Rigidbody2D gemRigidbody = gem.GetComponent<Rigidbody2D>();

            // Calculate a random bounce direction
            Vector2 bounceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f)).normalized;

            // Apply the bounce force to the gem
            gemRigidbody.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);

            // Attach a gem collector script to the gem
            Gem gemCollector = gem.AddComponent<Gem>();
            gemCollector.collectGemCallback += CollectGemCallback;
        }
    }

    private void CollectGemCallback()
    {
        gemsCollected++;
    }
}
