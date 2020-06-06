using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController2D))]
public class Character : MonoBehaviour
{
	public CharacterController2D Controller;
	//Animator animator;
	public Animator animator;
	public float runSpeed = 40f;

	public float health = 10f;

	float horizontalMove = 0f;
	bool jump = false;

	private Material matWhite;
	private Material matDefault;
	private SpriteRenderer sr;
	
	public Camera MainCamera; //be sure to assign this in the inspector to your main camera
	// Camera bounds
	private Vector2 screenBounds;
	private float objectWidth;
	private float objectHeight;
	// Update is called once per frame
	void Awake() {
		animator = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
		// replace on drag&&drap technology
		matWhite = Resources.Load("Flash", typeof(Material)) as Material;
		matDefault = sr.material;
	}
	void Start()
	{
		objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
		objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
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



	}

	void FixedUpdate()
	{
		// Move our character
		Controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}
	

	// Update is called once per frame
	void LateUpdate()
	{
		screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
		var viewPos = transform.position; 
		viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
		viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
		transform.position = viewPos;
	}
	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
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
