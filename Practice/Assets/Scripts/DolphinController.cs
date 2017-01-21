using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolphinController : MonoBehaviour {

    public float speedX, forceY;
    public Rigidbody2D playerRigidbody;

    public CapsuleCollider2D playerCollider;


	// Use this for initialization
	void Start () {
        if (gameObject.GetComponent<CapsuleCollider2D>())
            playerCollider = gameObject.GetComponent<CapsuleCollider2D>();
        
        if (gameObject.GetComponent<Rigidbody2D>())
            playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		forceY = Input.GetAxis("Vertical");
		
        playerRigidbody.AddForce(new Vector2(0, forceY));
    }
}
