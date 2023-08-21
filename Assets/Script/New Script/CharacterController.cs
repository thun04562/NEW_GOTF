using UnityEngine.Events;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          
	[Range(0, 1)] [SerializeField] private float m_SitSpeed = .36f;          
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  
	[SerializeField] private bool m_AirControl = false;                        
	[SerializeField] private LayerMask m_WhatIsGround;                          
	[SerializeField] private Transform m_GroundCheck;                          
	[SerializeField] private Transform m_CeilingCheck;                          
	[SerializeField] private Collider2D m_SitDisableCollider;                

	const float k_GroundedRadius = .2f; 
	private bool m_Grounded;            
	const float k_CeilingRadius = .2f; 
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnSitEvent;
	private bool m_wasSitting = false;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnSitEvent == null)
			OnSitEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool sit, bool jump)
	{
		// If sitting, check to see if the character can stand up
		if (!sit)
		{
			// If the character has a ceiling preventing them from standing up, keep them sitting
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				sit = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If sitting
			if (sit)
			{
				if (!m_wasSitting)
				{
					m_wasSitting = true;
					OnSitEvent.Invoke(true);

				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= m_SitSpeed;

				// Disable one of the colliders when crouching
				if (m_SitDisableCollider != null)
					m_SitDisableCollider.enabled = false;
			}
			else
			{
				// Enable the collider when not crouching
				if (m_SitDisableCollider != null)
					m_SitDisableCollider.enabled = true;

				if (m_wasSitting)
				{
					m_wasSitting = false;
					OnSitEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		transform.Rotate(0f, 180f, 0f);
	}
}
