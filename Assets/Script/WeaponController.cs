using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private AudioClip ShootSound;
    public Transform firePoint;
    public GameObject ammotype;

    public float shotSpeed;
    public float shotCounter, fireRate;

    //private Animator playerAnim;

    void Start()
    {
        //playerAnim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        SoundManager.instance.PlaySound(ShootSound);
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

        GameObject shot = Instantiate(ammotype, firePoint.position, firePoint.rotation);
        Rigidbody2D shotRB = shot.GetComponent<Rigidbody2D>();
        shotRB.AddForce(firePoint.right * shotSpeed * playerDir(), ForceMode2D.Impulse);

        Destroy(shot.gameObject, 1f);
    }
}
