using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10; // Damage to inflict on the player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enemy hit the player!");

            PlayerHealthManager playerHealth = collision.GetComponent<PlayerHealthManager>();
            if (playerHealth != null)
            {
                Debug.Log("PlayerHealthManager found on the player.");
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
