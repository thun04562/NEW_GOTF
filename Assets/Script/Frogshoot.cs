using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frogshoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject ammotype;
    public Transform player;

    [SerializeField] private float speedToPlayer = 1.0f;

    public float radius;

    public float shotSpeed;
    public float shotCounter, fireRate;

    //private Animator playerAnim;

    void Start()
    {
        //playerAnim = GetComponentInParent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        float playerDistance = Vector2.Distance(player.position, transform.position);
        Vector3 playerToTarget = player.position - transform.position;

        if (playerDistance < radius) 
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = fireRate;
                Shoot();
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Shoot()
    {
        int playerDir()
        {
            if (transform.parent.localScale.x < 0f)
            {
                return -1;
            }

            else
            {
                return +1;
            }
        }
        //transform.position = Vector3.MoveTowards(transform.position, player.position, speedToPlayer);

        GameObject shot = Instantiate(ammotype, firePoint.position, firePoint.rotation);
        Rigidbody2D shotRB = shot.GetComponent<Rigidbody2D>();
        shotRB.AddForce(firePoint.right * shotSpeed * playerDir(), ForceMode2D.Impulse);

        Destroy(shot.gameObject, 1f);
    }

}
