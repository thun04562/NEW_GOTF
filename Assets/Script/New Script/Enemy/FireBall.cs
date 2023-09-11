using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Reference to the explosion animation
    public Animator explosionAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the fireBall collided with the ground layer (you may need to adjust the layer mask)
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Trigger the explosion animation
            TriggerExplosion();
        }
    }

    private void TriggerExplosion()
    {
        // Ensure the explosionAnimator is assigned
        if (explosionAnimator != null)
        {
            // Trigger the explosion animation
            explosionAnimator.SetTrigger("Explode");

            // Optionally, you can destroy the fireBall GameObject after the explosion animation is played
            Destroy(gameObject, explosionAnimator.GetCurrentAnimatorClipInfo(0).Length);
        }
    }
}
