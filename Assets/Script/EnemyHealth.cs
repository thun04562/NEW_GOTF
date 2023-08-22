using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private AudioClip EnemyDeadSound;
    public int health = 100;
    public GameObject deathEffect;

    //private int currentHealth;

    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    /*void Start()
    {
        currentHealth = health;
        
    }*/

    /*void Update()
    {
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Dead");
            Destroy(gameObject, 0.3f);
            SoundManager.instance.PlaySound(EnemyDeadSound);
        }
 
    }*/


    /*public void damageEnemy(int damage)
    {
        currentHealth -= damage;


    } */

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
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
