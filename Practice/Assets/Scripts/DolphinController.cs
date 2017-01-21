using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinController : MonoBehaviour
{

	public float speed = 10;
	private Rigidbody rig;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
	public float hSpeed;

    // Use this for initialization
    void Start()
	{

		rig = GetComponent<Rigidbody>();

	}

	// Update is called once per frame
	void Update()
	{
		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");

		Vector3 movement = new Vector2(hAxis, vAxis) * speed * Time.deltaTime;
		rig.MovePosition(transform.position + movement);


		hSpeed = movement.x;

		if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        //bullet.GetComponent<Rigidbody>().velocity = new Vector3(5F, 0, 0);
        //bullet.GetComponent<Rigidbody>().velocity = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        sp.z = 0;
        Vector3 dir = (Input.mousePosition - sp).normalized;
        bullet.GetComponent<Rigidbody>().AddForce(dir * 100);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

}
