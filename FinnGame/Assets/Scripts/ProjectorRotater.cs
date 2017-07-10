using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorRotater : MonoBehaviour {

	DolphinController controller;
	float rotationAngle;

	// Use this for initialization
	void Start ()
	{
		rotationAngle = 0;
		controller = GameObject.FindGameObjectWithTag("Player").GetComponent<DolphinController>();
	}
	
	// Update is called once per frame
	void Update () {
		rotationAngle += controller.hSpeed * Time.deltaTime * 50;

		if (rotationAngle <= 85.0f)
			rotationAngle = 95;

		else if (rotationAngle >= 95.0f)
			rotationAngle = 85;
		
			transform.eulerAngles = new Vector3(rotationAngle, 90, 90);
	}
}
