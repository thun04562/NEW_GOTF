using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    //public GameObject skullBone, smallBone, rBone, lBone;

    //public static int health;
    public static int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    [SerializeField] private float startingHealth;
    [SerializeField] private Behaviour[] components;

    public float currentHealth { get; private set; }
    private Animator anim;
    private SpriteRenderer spriteRend;
    private bool dead;

    private void Awake()
    {
        health = 3;
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
        }

        else
        {
            if (!dead)
            {
                foreach (Behaviour component in components)
                    component.enabled = false;

                anim.SetBool("grounded", true);
                anim.SetTrigger("Die");
                
                dead = true;
            }
        }
    }

    private void Die()
    {
        if (!dead)
        {
            foreach (Behaviour component in components)
                component.enabled = false;

            anim.SetBool("grounded", true);
            anim.SetTrigger("Die");

           


            dead = true;
            // You might want to add additional code here, such as showing a game over screen.
        }
    }

    public void Respawn()
    {
        dead = false;
        currentHealth = startingHealth;
        anim.ResetTrigger("Die");
        anim.Play("Idle");

        foreach (Behaviour component in components)
            component.enabled = true;
    }


    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    /*public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("Die");
        anim.Play("Idle");

        foreach (Behaviour component in components)
            component.enabled = true;
    }*/
}
