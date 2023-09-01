using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] public HealthHeart _healthHeart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enemy hit the player!");
            Damage();
            /*PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Debug.Log("PlayerHealthManager found on the player.");
                playerHealth.TakeDamage(damage);
            }*/
        }
    }

    void Damage()
    {
        //_healthHeart.playerHealth= _healthHeart.playerHealth - damage;
        //_healthHeart.UpdateHealth();
        gameObject.SetActive(false);
    }
}
