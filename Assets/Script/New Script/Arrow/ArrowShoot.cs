using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    public GameObject explodeEffect;


    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void SetDirection(float _direction)
    {
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
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

        Instantiate(explodeEffect,transform.position,transform.rotation);

        Destroy(gameObject);
    }


    
}
