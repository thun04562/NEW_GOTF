using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private AudioClip EnemyDeadSound;
    
    public int healthEnemy;

    public GameObject deathEffect;

    //private int currentHealth;

    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

    }



    public void TakeDamage(int damage)
    {
        healthEnemy -= damage;
        
        if (healthEnemy <= 0)
        {
            Die();
        }
        else
        {
            anim.SetTrigger("Hurt");
        }
    }


    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
