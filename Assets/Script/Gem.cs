using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public delegate void CollectGemCallback();
    public CollectGemCallback collectGemCallback;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Check if the collider belongs to the player
            //Debug.Log("Gem collected!");
            var collect = FindObjectOfType<PlayerControl>();
            collect.CollectGem();
            CollectGem();
        }
    }

    private void CollectGem()
    {
        
        // Trigger the gem collection callback
        if (collectGemCallback != null)
        {
            collectGemCallback.Invoke();
        }

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator DelayCollect()
    {
        //SoundManager.instance.PlaySound(hurtSound);
        
        yield return new WaitForSeconds(3);
    
    }

}
