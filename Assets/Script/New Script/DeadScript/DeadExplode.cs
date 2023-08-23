using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadExplode : MonoBehaviour
{
    [SerializeField] private AudioClip EnemyDeadSound;
    public int health;
    public GameObject skullBone, smallBone, rBone, lBone;

    private bool isDead = false;
    //private int currentHealth;

    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

    }



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
        // Play death sound
        SoundManager.instance.PlaySound(EnemyDeadSound);

        // Spawn body parts
        Instantiate(skullBone, transform.position, Quaternion.identity);
        Instantiate(smallBone, transform.position, Quaternion.identity);
        Instantiate(rBone, transform.position, Quaternion.identity);
        Instantiate(lBone, transform.position, Quaternion.identity);
        Instantiate(rBone, transform.position, Quaternion.identity);
        Instantiate(lBone, transform.position, Quaternion.identity);

        // Deactivate the main enemy GameObject
        gameObject.SetActive(false);

        isDead = true;

        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(gameObject);
    }

    /*[SerializeField] GameObject bullet;
    public GameObject skullBone, smallBone, rBone, lBone;
    [SerializeField] private AudioClip EnemyDeadSound;

    float fireRate;
    float nextFire;
    bool isFiring = false;

    public int health;
    private bool isDead = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        fireRate = 1f;
        nextFire = Time.time;
    }

    private void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time >= nextFire && !isFiring)
        {
            isFiring = true;
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
            isFiring = false;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            // Play hurt animation
            anim.SetTrigger("Hurt");

            // Reduce health
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        // Play death sound
        SoundManager.instance.PlaySound(EnemyDeadSound);

        // Spawn body parts
        Instantiate(skullBone, transform.position, Quaternion.identity);
        Instantiate(smallBone, transform.position, Quaternion.identity);
        Instantiate(rBone, transform.position, Quaternion.identity);
        Instantiate(lBone, transform.position, Quaternion.identity);
        Instantiate(rBone, transform.position, Quaternion.identity);
        Instantiate(lBone, transform.position, Quaternion.identity);

        // Deactivate the main enemy GameObject
        gameObject.SetActive(false);

        isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Arrow")
        {
            TakeDamage(20); // Assuming arrow inflicts 20 damage
        }
    }*/
}
