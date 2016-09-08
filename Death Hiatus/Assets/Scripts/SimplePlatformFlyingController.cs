﻿using UnityEngine;
using System.Collections;

public class SimplePlatformFlyingController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 100f;
	public Transform HumanHero;

	private Animator anim;
	private Rigidbody2D rb2d;
	private float timer = 0.05f;


	// Use this for initialization
	void Awake () 
	{
		//anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if (Input.GetButtonDown("Jump") && timer<=0)
		{	
			timer = 0.05f;
			jump = true;
		}
	
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");

		//anim.SetFloat("Speed", Mathf.Abs(h));

		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * h * moveForce);

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();

		if (jump)
		{
			//anim.SetTrigger("Jump");
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
