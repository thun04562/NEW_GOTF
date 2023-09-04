using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
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
}
