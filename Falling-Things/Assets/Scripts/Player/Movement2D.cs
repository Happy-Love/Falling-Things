using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Movement2D : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	private float moveInput;

	private Rigidbody2D rb;

	private bool facingRight = true;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;

	private int extraJumps;
	public int extraJumpsValue;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		Jump();
		
	}
	void FixedUpdate()
	{
		Move();	
	}
	void Move()
	{
		moveInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
		if (facingRight == false && moveInput > 0)
		{
			Flip();
		}
		else if (facingRight == true && moveInput < 0)
		{
			Flip();
		}
	}
	void Flip() {
		facingRight = !facingRight;
		// Add Rotation instead Scaler
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}

	bool isGround() {
		return Physics2D.OverlapCircleAll(groundCheck.position, checkRadius, whatIsGround).Length==1;
	}
	void Jump()
	{
		if (isGround())
		{
			extraJumps = 2;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
		{
			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGround() == true)
		{
			rb.velocity = Vector2.up * jumpForce;
		}
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
	}



}
