using UnityEngine;
using System.Collections;

public class DropInanimateController : MonoBehaviour {

	public Transform sameObject;

	private Transform respawn;

	private bool dead = false;
	private Vector2 initialPos;


	// Use this for initialization
	void Start () {

		initialPos = transform.position;
		respawn = (Transform) Instantiate(sameObject, transform.position, Quaternion.identity);
		respawn.parent = transform;

	}
	
	// Update is called once per frame
	void Update () {

		if(dead)
		{
			respawn = (Transform) Instantiate(sameObject, transform.position, Quaternion.identity); // create another instance of the enemy
			respawn.parent = transform; // set the instance as child of the spawner
			dead = false; // prevents an infinite respawn
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "ground")
		{
			transform.position = initialPos;
			Destroy(respawn.gameObject);
			dead = true;
		}
	}

}
