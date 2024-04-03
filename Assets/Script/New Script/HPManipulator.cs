using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManipulator : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var _playerHurt = collision.GetComponent<PlayerHurt>();

            if(HealthHeart.playerHealth < 3)
            _playerHurt.Heal();

            Destroy(this);
        }
    }
}
