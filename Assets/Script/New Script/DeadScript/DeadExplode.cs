using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadExplode : MonoBehaviour
{
    [SerializeField] private AudioClip EnemyDeadSound;
    public int health;
    public GameObject skullBone, smallBone, rBone, lBone;

    private bool isDead = false;


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


}
