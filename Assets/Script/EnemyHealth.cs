using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private AudioClip EnemyDeadSound;
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
            animator.SetTrigger("Dead");
            Destroy(gameObject, 0.3f);
            SoundManager.instance.PlaySound(EnemyDeadSound);
        }
 
    }

    public void damageEnemy(int damage)
    {
        currentHealth -= damage;

    } 
}
