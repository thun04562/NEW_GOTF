using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Collider2D coll;

    [SerializeField] private LayerMask ground;


    private enum State {idle, running, sitting, dashing, jumping, falling }
    private State state = State.idle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        AnimationState();
        anim.SetInteger("state", (int)state);
    }
    void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        //เคลื่อนที่ไปทางซ้าย
        if (hDirection < 0)
        {
            
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            //anim.SetBool("running", true);
        }
        //เคลื่อนที่ไปทางขวา
        else if (hDirection > 0)
        {
            
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            //anim.SetBool("running", true);
        }
        else
        {
            //anim.SetBool("running", false);
        }
        //กด spec กระโดด
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x,10);
            state = State.jumping;
        }

        if (Input.GetKey(KeyCode.S) )
        {
            //rb.velocity = new Vector2(rb.velocity.x, 0);
            state = State.sitting;
            anim.SetBool("sit", true);
        }
        else
        {
            anim.SetBool("sit", false);
        }
    }
    void AnimationState()
    {
        if (state == State.jumping)
        {
            if(rb.velocity.y < 0.1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }

        else if (Mathf.Abs(rb.velocity.x)> 0.1f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }

    }
}
