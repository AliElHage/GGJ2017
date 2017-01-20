using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {

    private Transform characterTransform;
    private Vector2 moveSpeed;
    public float speed;
    private CharacterController myController;

	// Use this for initialization
	void Start () {
        //characterTransform = GetComponent<Transform>();
        myController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            myController.Move(Vector3.right);
        }
        if (Input.GetKey(KeyCode.S))
        {
            myController.Move(Vector3.down);
        }
	}

}
