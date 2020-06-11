using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	// Start is called before the first frame update
	public float jumpHeight = 10f;
	public float jumpCutHeight = 5f;
 


	[SerializeField] private float m_JumpForce = 15000f;                          // Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	public bool IsGrounded { get => m_Grounded; }
	[Header("Events")]
	[Space]
	public UnityEvent OnLandEvent;
	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}
	 

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
				{
					OnLandEvent.Invoke();
				}
			}
		}
	}


	public void Move(float move)
	{
		 
		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			 
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
		
	}

	public void Jump2() {
		if (m_Grounded)
		{  
			
			float g = m_Rigidbody2D.gravityScale * Physics2D.gravity.magnitude;
			//m_Rigidbody2D.velocity = new Vector3(m_Rigidbody2D.velocity.x, m_Rigidbody2D.transform.position.y * jumpHeight);
			//float a = m_JumpForce / m_Rigidbody2D.mass;	
			//float jump_y = max_jump_y - (max_jump_y * myDrag * Time.fixedDeltaTime);
			//print("Max jump y"+max_jump_y);
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce), ForceMode2D.Impulse);
			float max_jump_y = (m_Rigidbody2D.velocity.y * m_Rigidbody2D.velocity.y) / (2 * g);
			
			print(max_jump_y);
			
		}		
	}
	public void Jump() {
		if (m_Grounded)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce), ForceMode2D.Impulse); // doesn't work
			
 
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;
		transform.Rotate(0f, 180f, 0f);
	}
}
