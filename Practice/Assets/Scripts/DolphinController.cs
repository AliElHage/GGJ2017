using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinController : MonoBehaviour
{

	public float speed = 10;
	private Rigidbody2D rig;

	// Use this for initialization
	void Start()
	{

		rig = GetComponent<Rigidbody2D>();

	}

	// Update is called once per frame
	void Update()
	{

		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");

		Vector3 movement = new Vector2(0, vAxis) * speed * Time.deltaTime;
		rig.MovePosition(transform.position + movement);

	}
}
