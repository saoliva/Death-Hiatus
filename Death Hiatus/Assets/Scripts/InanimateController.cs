using UnityEngine;
using System.Collections;

public class InanimateController : MonoBehaviour {

	public Transform inanimateElement;


	// Use this for initialization
	void Awake () 
	{
		//anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "InanimateElement")
		{
			Vector2 playerPos = gameObject.transform.position;
			Destroy(gameObject);
			Instantiate(inanimateElement, playerPos, Quaternion.identity);

		}
	}

}
