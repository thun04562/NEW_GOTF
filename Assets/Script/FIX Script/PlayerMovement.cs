using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private AudioClip jumpSound;
	[SerializeField] private AudioClip runSound;
	public CharacterController controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool sit = false;

	void Update()
	{
		SoundManager.instance.PlaySound(runSound);
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			//if(Input.GetKeyDown(KeyCode.Space) /*&& isGrounded()*/)
			//SoundManager.instance.PlaySound(jumpSound);
			jump = true;
			SoundManager.instance.PlaySound(jumpSound);
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetKey(KeyCode.S))
		{
			sit = true;
			animator.SetBool("IsSitting", true);
			
		}

		else
		{
			animator.SetBool("IsSitting", false);
		}

	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	public void OnSitting(bool isSitting)
	{
		animator.SetBool("IsSitting", isSitting);
		
	}

	void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, sit, jump);
		jump = false;
	}
}