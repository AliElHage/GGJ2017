using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinController : MonoBehaviour
{

	public float speed = 10;
	private Rigidbody2D rig;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

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
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(5F, 0, 0);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
