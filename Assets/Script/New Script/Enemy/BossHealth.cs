using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private AudioClip EnemyDeadSound;
    public GameObject skullBone, smallBone, rBone, lBone;


    public Animator anim;

    public UiBossBar healthBar;

    public int health = 50;

	public bool isInvulnerable = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(health);

    }

    public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;
        healthBar.SetHealth(health);

		if (health <= 20)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
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

        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(gameObject);
    }

}