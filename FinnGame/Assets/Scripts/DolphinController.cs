using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinController : MonoBehaviour
{

	public float speed, projectileSpeed;
	private Rigidbody rig;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public float hSpeed;

	private AudioSource source;
	public AudioClip sonarSound;
	//public AudioClip deathCry;
	public AudioClip collisionPillarSound;
	public AudioClip mineExplosionSound;

	public GameObject deathScreen;

	// Use this for initialization
	void Start()
	{
		source = GetComponent<AudioSource>();
		Renderer renders = gameObject.GetComponent<Renderer>();
		renders.material.renderQueue = 1;
		rig = GetComponent<Rigidbody>();

	}

	// Update is called once per frame
	void Update()
	{
		//float hAxis = Input.GetAxis("Horizontal");
		float hAxis = speed / 4;
		float vAxis = Input.GetAxis("Vertical");

		Vector3 movement = new Vector2(hAxis, vAxis) * speed * Time.deltaTime;
		rig.MovePosition(transform.position + movement);


		hSpeed = movement.x;

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Fire();
		}

	}

	void Fire()
	{
		//Audio
		source.PlayOneShot(sonarSound, .75f);
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		
		// Add velocity to the bullet
		//bullet.GetComponent<Rigidbody>().velocity = new Vector3(5F, 0, 0);
		//bullet.GetComponent<Rigidbody>().velocity = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Camera cam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
		Vector3 sp = cam.WorldToScreenPoint(bulletSpawn.position);
		sp.z = 0;
		Vector3 dir = (Input.mousePosition - sp).normalized;
		bullet.GetComponent<Rigidbody>().AddForce(dir * projectileSpeed);

		bullet.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().startRotation = Mathf.Atan2(dir.x, dir.y) + Mathf.PI;

		
		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}

	void OnCollisionEnter(Collision collision)
	{
		//For pillars
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Pillar"))
		{
			source.PlayOneShot(collisionPillarSound, .88f);
			deathScreen.SetActive(true);		

			Debug.Log("Touched a pillar");

		}	
	}
	void OnTriggerEnter(Collider colider)
	{

		if (colider.gameObject.layer == LayerMask.NameToLayer("MineTrigger"))
		{
			deathScreen.SetActive(true);
			Debug.Log("You just got bombed!");
		}
	}

}
