using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public GameObject skullBone, smallBone, rBone, lBone;

    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;

    //public GameObject UIGameover;
    public Animator animator;

    private bool isDead = false;

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            PlayerHealthManager.health--;
            if (PlayerHealthManager.health <= 0)
            {
                //UIGameover.SetActive(true);
                SoundManager.instance.PlaySound(deathSound);

                Instantiate(skullBone, transform.position, Quaternion.identity);
                Instantiate(smallBone, transform.position, Quaternion.identity);
                Instantiate(rBone, transform.position, Quaternion.identity);
                Instantiate(lBone, transform.position, Quaternion.identity);

                gameObject.SetActive(false);
            }
            else
            {
                animator.SetTrigger("PlayerHurt");
                StartCoroutine(GetHurt());
            }
        }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead && collision.transform.tag == "Enemy")
        {
            PlayerHealthManager.health--;
            if (PlayerHealthManager.health <= 0)
            {
                // Play death sound
                SoundManager.instance.PlaySound(deathSound);

                // Spawn body parts
                Instantiate(skullBone, transform.position, Quaternion.identity);
                Instantiate(smallBone, transform.position, Quaternion.identity);
                Instantiate(rBone, transform.position, Quaternion.identity);
                Instantiate(lBone, transform.position, Quaternion.identity);
                Instantiate(rBone, transform.position, Quaternion.identity);
                Instantiate(lBone, transform.position, Quaternion.identity);


                // Deactivate the main player GameObject
                gameObject.SetActive(false);

                isDead = true;
            }
            else
            {
                // Play hurt animation
                animator.SetTrigger("PlayerHurt");
                StartCoroutine(GetHurt());
            }
        }
    }

    IEnumerator GetHurt()
        {
            SoundManager.instance.PlaySound(hurtSound);
            Physics2D.IgnoreLayerCollision(7, 8);
            yield return new WaitForSeconds(1);
            Physics2D.IgnoreLayerCollision(7, 8, false);
        }
    }

