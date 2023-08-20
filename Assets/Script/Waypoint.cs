using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    public bool facingLeft = true;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (facingLeft)
        {
            if (transform.localScale.x == -1)
            {
                transform.localScale = new Vector3(1, 1);
            }

            if (transform.position.x > leftCap)
            {
                rb.velocity = new Vector2(-5, 0);
            }

            else
            {
                facingLeft = false;
            }
        }

        else
        {
            if (transform.localScale.x == 1)
            {
                transform.localScale = new Vector3(-1, 1);
            }

            if (transform.position.x < rightCap)
            {
                rb.velocity = new Vector2(5, 0);
            }

            else
            {
                facingLeft = true;
            }
        }
    }
}
