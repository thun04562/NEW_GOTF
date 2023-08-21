using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackCooldown;
    private Animator anim;
    private PlayerControl playerControl;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerControl = GetComponent<PlayerControl>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerControl.canAttack()) 
            playerAttack();

        cooldownTimer += Time.deltaTime;
    }

    private void playerAttack()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;
    }
}

