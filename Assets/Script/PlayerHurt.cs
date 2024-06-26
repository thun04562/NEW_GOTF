using System.Collections;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public GameObject skullBone, smallBone, rBone, lBone;

    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;

    public Animator animator;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            TakeDamage();
        }
        if (collision.transform.tag == "Fire")
        {
            TakeDamage();
        }
    }

    public void Heal() => HealthHeart.playerHealth++;

    public void TakeDamage()
    {
        HealthHeart.playerHealth--;

        if (HealthHeart.playerHealth <= 0)
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

            //StartCoroutine(Dead());
            GameOverUI.isGameOver = true;


            //gameObject.SetActive(false);

        }
        else
        {
            // Play hurt animation
            animator.SetTrigger("PlayerHurt");
            StartCoroutine(GetHurt());
        }
    }

  

    IEnumerator GetHurt()
    {
            SoundManager.instance.PlaySound(hurtSound);

            Physics2D.IgnoreLayerCollision(7, 8);
            yield return new WaitForSeconds(1);
            Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    /*IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.2f);
        GameOverUI.isGameOver = true;
    }*/
}


