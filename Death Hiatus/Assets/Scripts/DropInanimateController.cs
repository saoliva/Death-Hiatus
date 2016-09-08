using UnityEngine;
using System.Collections;

public class DropInanimateController : MonoBehaviour {

	public Transform sameObject;

	private Transform respawn;

	private bool dead = false;
	private Vector3 initialPos;

	void Awake()
	{
		initialPos = transform.position;
	}


	// Use this for initialization
	void Start () {

		respawn = (Transform) Instantiate(sameObject, transform.position, Quaternion.identity);
		respawn.parent = transform;

	}
	
	// Update is called once per frame
	void Update () {

		if(dead)
		{
			transform.position = initialPos;
			respawn = (Transform) Instantiate(sameObject, transform.position, Quaternion.identity); // create another instance of the enemy
			respawn.parent = transform; // set the instance as child of the spawner
			dead = false; // prevents an infinite respawn
		}
		respawn.transform.localPosition = new Vector2(0,0);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "ground")
		{
			Destroy(respawn.gameObject);
			dead = true;
		}
	}

}
