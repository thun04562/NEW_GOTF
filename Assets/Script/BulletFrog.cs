using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFrog : MonoBehaviour
{
    public int bulletDamage;
    public GameObject ArrowEffect;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealthManager.health--;

        }
        Instantiate(ArrowEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
     
}
