using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private AudioClip EnemyDeadSound;
    
    public int healthEnemy;

    public GameObject deathEffect;

    [SerializeField] private GameObject DroppingHeart;
    //private int currentHealth;

    public Animator anim;

    private void OnValidate()
    {
        if (!DroppingHeart)
        {
            string _path = "Assets/Prefabs/Heart";
            var _gameObject = Resources.Load<GameObject>(_path);
            DroppingHeart = _gameObject;
        }
    }

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


    private void RandomChance()
    {
        bool _isDropped = Random.Range(0, 3) >= 2;

        if (_isDropped) Instantiate(DroppingHeart, transform.position, Quaternion.identity);
    }

    void Die()
    {
        RandomChance();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
