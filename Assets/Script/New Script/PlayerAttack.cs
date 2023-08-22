using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
           
        }
        
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
               
    }

    


    /*[SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] REDarrow;
    //private Animator anim;
    private PlayerControl playerControl;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
        playerControl = GetComponent<PlayerControl>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && playerControl.canAttack()) 
            playerAttack();

        cooldownTimer += Time.deltaTime;
    }

    private void playerAttack()
    {
        //anim.SetTrigger("Attack");
        cooldownTimer = 0;

        REDarrow[0].transform.position = firePoint.position;
        REDarrow[0].GetComponent<RedArrowShoot>().SetDirection(Mathf.Sign(transform.localScale.x));

        //pool redarrow
    }*/
}

