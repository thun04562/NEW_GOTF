using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManipulator : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.CompareTag("Player"))
        {
            var _playerHurt = _collision.gameObject.GetComponent<PlayerHurt>();

            if (HealthHeart.playerHealth < 3)
                _playerHurt.Heal();

            Destroy(this.gameObject);
        }
    }
}
