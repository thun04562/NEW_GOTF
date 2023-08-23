using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBulletEnemy : MonoBehaviour
{
	public float moveSpeed = 7f;

	Rigidbody2D rb;

	PlayerControl target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<PlayerControl>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, 1.5f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals("Player"))
		{
			Debug.Log("Hit!");
			Destroy(gameObject);
		}
	}
}
