using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip runSound;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    //private SpriteRenderer sprite;
    private Animator anim;

    public bool isFacingRight = true;


    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1.0f;

    public Image ManaBar;
    public float Mana, maxMana;
    public float ManaCost;

    public float runcost;
    public float chargeRate;

    public Coroutine recharge;

    [SerializeField]private TrailRenderer tr;

    public static int numberOfGems;
    public Text gemCountText;
    public int gemCount;

    public void CollectGem()
    {
        Debug.Log("CollectGem Worked");
        gemCount += 10;
        PlayerPrefs.SetInt("GemCount", gemCount);
        UpdateGemCountUI();
        PlayerPrefs.Save();

    }

    public void UpdateGemCountUI()
    {
        gemCount = PlayerPrefs.GetInt("GemCount");
        if (gemCountText != null)
        {
            gemCountText.text = gemCount.ToString();
        }
    }

    public void ClearGemCountIfReturningToGameplay1()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay1")
        {
            
            // Clear gem count when going back to the "Gameplay1" scene.
            UpdateGemCountUI();
            PlayerPrefs.DeleteAll();
        }
    }

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;

    private bool isSitting = false;

    private enum MovementState { Idle, Running, Jumping, Falling, Sitting, JumpShooting, FallShooting }
    private MovementState state = MovementState.Idle;

    private void Start()
    {
        Debug.Log("You Come in PlayerControl");
        // Initialize gem count from PlayerPrefs or set to 0 if not found
        gemCount = PlayerPrefs.GetInt("GemCount",0);
        UpdateGemCountUI();


        isFacingRight = true;


        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        //sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }


        // Player jump input
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            SoundManager.instance.PlaySound(jumpSound);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            

        }

        // Player move input
        dirX = Input.GetAxisRaw("Horizontal");
        SoundManager.instance.PlaySound(runSound);


        // Check if the player is falling and holding the Sit button, prioritize sitting
        if (Input.GetButton("Sit") && IsGrounded())
        {
            isSitting = true;
            anim.SetBool("isSitting", isSitting);
        }
        else
        {
            
            isSitting=false;
            anim.SetBool("isSitting", isSitting);
            

        }


        if (isSitting && IsGrounded())
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }


        // Flip the player sprite based on the movement direction

       
        if (dirX > 0.01f && !isFacingRight)
        {
            Flip();


        }
        else if(dirX < -0.01f && isFacingRight)
        {
            Flip();
            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && Mana >= 25)
        {

            Mana -= ManaCost;
            if (Mana < 0)
            {
                Mana = 0;
            }
            ManaBar.fillAmount = Mana / maxMana;
            StartCoroutine(Dash());
            
            if(recharge != null)
            {
                StopCoroutine(recharge);
                recharge = StartCoroutine(RechargeMana());
            }
            
            
        }
        
        
        
        AnimationState();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }



    private void AnimationState()
    {
        MovementState currentState = state;

        if (isSitting)
        {
            state = MovementState.Sitting;
           
        }
        else if (dirX > 0f)
        {
            state = MovementState.Running;
        }
        else if (dirX < 0f)
        {
            state = MovementState.Running;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.Jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.Falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    public bool canAttack()
    {
        return dirX == 0 && IsGrounded();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
 

    private IEnumerator Dash()
    {
        if (Mana >= ManaCost) // Check if there's enough mana to dash
        {
            // Deduct mana cost
            Mana -= ManaCost;
            if (Mana < 0)
            {
                Mana = 0;
            }
            ManaBar.fillAmount = Mana / maxMana;

            canDash = false;
            isDashing = true;
            float originalGravity = rb.gravityScale;
            rb.gravityScale = 0f;

            Vector2 dashDirection = isFacingRight ? Vector2.right : Vector2.left;
            rb.velocity = dashDirection * dashingPower;
            //rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);

            tr.emitting = true;
            yield return new WaitForSeconds(dashingTime);
            tr.emitting = false;
            rb.gravityScale = originalGravity;
            isDashing = false;
            yield return new WaitForSeconds(dashingCooldown);
            canDash = true;

            // Start mana recharge coroutine if not already started
            if (recharge == null)
            {
                recharge = StartCoroutine(RechargeMana());
            }
        }


    }

    private IEnumerator RechargeMana()
    {
        yield return new WaitForSeconds(1f);

        while (Mana < maxMana)
        {
            // Recharge mana
            Mana += chargeRate / 10f;
            if (Mana > maxMana)
            {
                Mana = maxMana;
            }
            ManaBar.fillAmount = Mana / maxMana;
            yield return new WaitForSeconds(.1f);
        }

        // Reset recharge coroutine
        recharge = null;
    }


}