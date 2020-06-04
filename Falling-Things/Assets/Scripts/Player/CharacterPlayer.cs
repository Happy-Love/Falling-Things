using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController2D))]
public class CharacterPlayer : MonoBehaviour
{
	public CharacterController2D controller;
	//Animator animator;
	public Animator animator;
	public float runSpeed = 40f;

	public float health = 10f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	private Material matWhite;
	private Material matDefault;
	SpriteRenderer sr;

	// Update is called once per frame
	void Awake() {
		animator = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
		matWhite = Resources.Load("Flash", typeof(Material)) as Material;
		matDefault = sr.material;
	}
	void Update()
	{

		horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			crouch = true;
		}
		else if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			crouch = false;
		}

	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	//public void OnCrouching(bool isCrouching)
	//{
	//	//animator.SetBool("IsCrouching", isCrouching);
	//}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		sr.material = matWhite;
		if (health <= 0)
		{
			OnDie();
		}
		else
		{
			Invoke("ResetMaterial", .3f);
		}
	}
	void ResetMaterial() {
		sr.material = matDefault;
	}
	void OnDie()
	{
		Destroy(gameObject);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
	}
}
