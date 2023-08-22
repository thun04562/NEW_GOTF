using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip runSound;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    public static int numberOfGems;
    public Text gemCountText;
    public int gemCount = 0;

    public void CollectGem()
    {
        Debug.Log("CollectGem Worked");
        gemCount++; 
        UpdateGemCountUI(); 
    }

    private void UpdateGemCountUI()
    {
        if (gemCountText != null)
        {
            gemCountText.text = gemCount.ToString();
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
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {


        // Player jump input
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            SoundManager.instance.PlaySound(jumpSound);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            

        }

        // Player move input
        dirX = Input.GetAxisRaw("Horizontal");
        SoundManager.instance.PlaySound(runSound);

        // Player shooting input (you can add this later if needed)
        // ...

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

        /*if (state == MovementState.Falling && Input.GetButton("Sit"))
        {
            isSitting = true;
        }
        else
        {
            // Player sitting input
            isSitting = Input.GetButton("Sit");
            anim.SetBool("isSitting", isSitting);
        }*/

        if (isSitting && IsGrounded())
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        /*// Update player's velocity based on the movement and sitting state
        if (!isSitting) // Player can move only if not sitting
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
        else // If sitting, set the velocity to zero
        {
            rb.velocity = Vector2.zero;
        }*/

        // Flip the player sprite based on the movement direction

        if (dirX > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(dirX < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        /* if (dirX < 0)
        {
            sprite.flipX = true;
        }
        else if (dirX > 0)
        {
            sprite.flipX = false;
        }*/

        // Update the animation state
        AnimationState();
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
}