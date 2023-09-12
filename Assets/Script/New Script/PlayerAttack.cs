using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    /*[SerializeField] private AudioClip ShootSound;

    public List<Transform> playerArrow;
    public GameObject greenArrowBulletPrefab;
    public GameObject blueArrowBulletPrefab;
    public GameObject yellowArrowBulletPrefab;
    public GameObject redArrowBulletPrefab; // Add a reference to the red arrow bullet prefab.
    public float reloadDelay = 1;

    public bool canShoot = true;
    private Collider2D[] playerColliders;
    private float currentDelay = 0;

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Call a method to switch the bullet prefab and update the UI.
            SwitchBulletPrefab();
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
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;
            foreach (var fireArrow in playerArrow)
            {
                GameObject bulletPrefab = GetCurrentBulletPrefab(); // Get the correct bullet prefab.
                if (bulletPrefab != null)
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

                else
                {
                    Debug.LogError("Invalid arrow type on the arrow: " + fireArrow.name);
                }
            }
        }
    }

    private GameObject GetCurrentBulletPrefab()
    {
        // Determine the appropriate bullet prefab based on the current arrow type.
        string currentArrowType = GetComponent<PlayerAnimationArrowController>().GetCurrentArrowType();

        switch (currentArrowType)
        {
            case "RedArrow":
                return redArrowBulletPrefab;
            case "GreenArrow":
                return greenArrowBulletPrefab;
            case "BlueArrow":
                return blueArrowBulletPrefab;
            case "YellowArrow":
                return yellowArrowBulletPrefab;
            default:
                Debug.LogError("Invalid arrow type: " + currentArrowType);
                return null;
        }
    }

    // Method to switch the bullet prefab and update the UI (called when pressing "R").
    private void SwitchBulletPrefab()
    {
        GetComponent<PlayerAnimationArrowController>().ChangeArrowAnimation("GreenArrow"); // Change arrow type to green.
    }*/

    [SerializeField] private AudioClip ShootSound;

    public List<Transform> playerArrow;
    public GameObject greenArrowBulletPrefab;
    public GameObject blueArrowBulletPrefab;
    public GameObject yellowArrowBulletPrefab;
    public GameObject redArrowBulletPrefab; // Add a reference to the red arrow bullet prefab.

    // Define reload delays for each arrow type
    public float greenArrowReloadDelay = 1f;
    public float blueArrowReloadDelay = 2f; // Add a reload delay for BlueArrow.
    public float yellowArrowReloadDelay = 1.5f;
    public float redArrowReloadDelay = 1f;

    private bool canShoot = true;
    private Collider2D[] playerColliders;
    private float currentDelay = 0;

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Call a method to switch the bullet prefab and update the UI.
            SwitchBulletPrefab();
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
        if (canShoot)
        {
            canShoot = false;
            // Get the reload delay based on the current arrow type
            float reloadDelay = GetCurrentArrowReloadDelay();
            currentDelay = reloadDelay;
            foreach (var fireArrow in playerArrow)
            {
                GameObject bulletPrefab = GetCurrentBulletPrefab(); // Get the correct bullet prefab.
                if (bulletPrefab != null)
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
                else
                {
                    Debug.LogError("Invalid arrow type on the arrow: " + fireArrow.name);
                }
            }
        }
    }

    private GameObject GetCurrentBulletPrefab()
    {
        // Determine the appropriate bullet prefab based on the current arrow type.
        string currentArrowType = GetComponent<PlayerAnimationArrowController>().GetCurrentArrowType();

        switch (currentArrowType)
        {
            case "RedArrow":
                return redArrowBulletPrefab;
            case "GreenArrow":
                return greenArrowBulletPrefab;
            case "BlueArrow":
                return blueArrowBulletPrefab;
            case "YellowArrow":
                return yellowArrowBulletPrefab;
            default:
                Debug.LogError("Invalid arrow type: " + currentArrowType);
                return null;
        }
    }

    // Method to switch the bullet prefab and update the UI (called when pressing "R").
    private void SwitchBulletPrefab()
    {
        GetComponent<PlayerAnimationArrowController>().ChangeArrowAnimation("GreenArrow"); // Change arrow type to green.
    }

    private float GetCurrentArrowReloadDelay()
    {
        // Determine the reload delay based on the current arrow type.
        string currentArrowType = GetComponent<PlayerAnimationArrowController>().GetCurrentArrowType();

        switch (currentArrowType)
        {
            case "RedArrow":
                return redArrowReloadDelay;
            case "GreenArrow":
                return greenArrowReloadDelay;
            case "BlueArrow":
                return blueArrowReloadDelay;
            case "YellowArrow":
                return yellowArrowReloadDelay;
            default:
                Debug.LogError("Invalid arrow type: " + currentArrowType);
                return 0f;
        }
    }


}
