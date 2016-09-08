using UnityEngine;
using System.Collections;

public class InanimatePlayerController : MonoBehaviour {

	public Transform groundCheck;

	private Rigidbody2D rb2d;
	private bool grounded = false;



	// Use this for initialization
	void Awake () 
	{
		//anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if(grounded)
			rb2d.isKinematic = true;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "InanimateElement")
		{
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());

		}
	}
}
