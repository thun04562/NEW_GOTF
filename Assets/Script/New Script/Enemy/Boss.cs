using BarthaSzabolcs.Tutorial_SpriteFlash;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] private AudioClip EnemyDeadSound;
    public GameObject skullBone, smallBone, rBone, lBone;
    public enum BossState { Idle, AttackIdle, IdleRed, IdleInEnraged }

    public BossState currentState = BossState.Idle;
    public float maxHP = 100f;
    public float currentHP;
    public Slider hpSlider;

    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    public float fireballSummonInterval = 10f;
    public float fireballSummonDuration = 5f;
    private float nextFireballSummonTime;

    private Animator anim;
    private float timeInCurrentState = 0f;

    private SimpleFlash simpleFlash;


    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHP = maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;
        nextFireballSummonTime = Time.time + fireballSummonInterval;
        simpleFlash = GetComponent<SimpleFlash>();

    }

    private void Update()
    {
        hpSlider.value = currentHP;
        timeInCurrentState += Time.deltaTime;

        switch (currentState)
        {
            case BossState.Idle:
                if (currentHP <= 0)
                {
                    Die();
                    Debug.Log("dead");
                }
                else if (currentHP <= 450)
                {
                    currentState = BossState.IdleRed;
                    timeInCurrentState = 0f;
                }
                else if (timeInCurrentState >= fireballSummonInterval * 2f)
                {
                    currentState = BossState.AttackIdle;
                    timeInCurrentState = 0f;
                }
                break;

            case BossState.AttackIdle:
                if (currentHP <= 0)
                {
                    Die();
                    Debug.Log("dead");
                }
                else if (currentHP <= 450)
                {
                    currentState = BossState.IdleRed;
                    timeInCurrentState = 0f;
                }
                else if (timeInCurrentState >= fireballSummonDuration * 5f)
                {
                    currentState = BossState.Idle;
                    timeInCurrentState = 0f;
                }
                else if (Time.time >= nextFireballSummonTime)
                {
                    SummonFireball();
                    nextFireballSummonTime = Time.time + fireballSummonInterval;
                }
                break;

            case BossState.IdleRed:
                if (currentHP <= 0)
                {
                    Die();
                    Debug.Log("dead");
                }
               
                else if (timeInCurrentState >= fireballSummonInterval * 2f) // Increase the interval
                {
                    currentState = BossState.IdleInEnraged;
                    timeInCurrentState = 0f;
                }

       
                break;

            case BossState.IdleInEnraged:
                if (currentHP <= 0)
                {
                    Die();
                    Debug.Log("dead");
                }
                else if (timeInCurrentState >= fireballSummonDuration * 4f)
                {

                    currentState = BossState.IdleRed;
                    timeInCurrentState = 0f;
                }
                else if (Time.time >= nextFireballSummonTime)
                {
                    SummonFireball();
                    nextFireballSummonTime = Time.time + fireballSummonInterval;
                }
                break;

  
        }

        // Update the boss's animation based on the current state
        UpdateAnimation();
    }


    private void SummonFireball()
    {
        // Check if the boss is in AttackIdle or IdleInEnraged state before summoning fireball
        if (currentState == BossState.AttackIdle || currentState == BossState.IdleInEnraged)
        {
            // Get the current animation state
            AnimatorStateInfo currentAnimation = anim.GetCurrentAnimatorStateInfo(0);

            // Check if the animation state is AttackIdle or IdleInEnraged
            if (currentAnimation.IsName("Attack-Idle") || currentAnimation.IsName("idleInEnraged"))
            {
                float X = Random.Range(minX, maxY);
                float Y = Random.Range(minY, maxY);
                Instantiate(fireballPrefab, transform.position + new Vector3(X, Y, 0), transform.rotation);
            }
        }
    }

    private void UpdateAnimation()
    {
        // Update the boss's Animator based on the current state
        anim.SetInteger("state", (int)currentState);
    }

    public void TakeDamage(float damage)
    {

        currentHP -= damage;
        
        hpSlider.value = currentHP;

        if (simpleFlash != null)
        {
            simpleFlash.Flash();
        }

        // Handle transitions based on HP (e.g., transition to IdleRed when HP is low)
        if (currentHP <= 0)
        {
            currentState = BossState.IdleRed;
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
        Destroy(gameObject);
    }
}