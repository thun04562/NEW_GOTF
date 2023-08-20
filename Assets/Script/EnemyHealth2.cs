using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth2 : MonoBehaviour
{
    public int health;
    private int currentHealth;
    public Animator animator;


    void Start()
    {
        currentHealth = health;

    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            //animator.SetTrigger("Dead");
            Destroy(gameObject);
        }

    }

    public void damageEnemy(int damage)
    {
        currentHealth -= damage;

    }
}