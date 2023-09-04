using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHurt player = collision.GetComponent<PlayerHurt>();
            if (player != null)
            {
                player.TakeDamage();
            }
        }

    }
}

/*
    private PlayerHurt playerHealth;

    private void Awake()
    {
        playerHealth = FindAnyObjectByType<PlayerHurt>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player"))
        {
            Debug.Log("Enemy hit the player!");
            Damage();
            
        }
    }

    void Damage()
    {
        playerHealth.TakeDamage();
    }
     */