using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private AudioClip ShootSound;

    public List<Transform> playerArrow;
    public GameObject bulletPrefab;
    public float reloadDelay = 1;

    //public Transform firePoint;

    public bool canShoot = true;
    private Collider2D[] playerColliders;
    public float currentDelay = 0;



    private bool isCharging;

    private void Awake()
    {
        playerColliders = GetComponentsInChildren<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }

    }

    public void Shoot()
    {
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;
            foreach (var fireArrow in playerArrow)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = fireArrow.position;
                bullet.transform.localRotation = fireArrow.rotation;
                bullet.GetComponent<ArrowShoot>().Initialized();

                foreach (var collider in playerColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                    SoundManager.instance.PlaySound(ShootSound);
                }
            }
        }
    }


}