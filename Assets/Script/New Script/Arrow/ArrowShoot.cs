using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;

    public float maxDistance = 10;
    private Vector2 startPosition;
    private float conquaredDistance = 0;

    public Rigidbody2D rb;
    public GameObject explodeEffect;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialized()
    {
        startPosition = transform.position;
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if(conquaredDistance > maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        DeadExplode explodeEnemy = hitInfo.GetComponent<DeadExplode>();
        if (explodeEnemy != null)
        {
            explodeEnemy.TakeDamage(damage);
        }

        Boss boss = hitInfo.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }

        Instantiate(explodeEffect,transform.position,transform.rotation);

        Destroy(gameObject);
    }


    
}
