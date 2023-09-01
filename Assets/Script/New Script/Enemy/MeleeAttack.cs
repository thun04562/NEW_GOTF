using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int attackDamage;
    [SerializeField] private BoxCollider2D boxColl;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private PlayerHurt playerHealth;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }
        }
        
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = 
        Physics2D.BoxCast(boxColl.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxColl.bounds.size.x * range,boxColl.bounds.size.y,boxColl.bounds.size.z),
        0,Vector2.left,0, playerLayer);
        return hit.collider != null;

        if(hit.collider != null) 
            playerHealth = hit.transform.GetComponent<PlayerHurt>();

        return hit.collider != null;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube (boxColl.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxColl.bounds.size.x * range, boxColl.bounds.size.y, boxColl.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            
        }
    }

}
