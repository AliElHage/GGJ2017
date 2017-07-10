using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
	public GameObject backgrounds;
	public float parallaxScales;
	public float smoothing = 1f;

	private Transform cam;
	private Vector3 previousCamPos;

	void Awake()
	{
		cam = GameObject.Find("PlayerCamera").transform;
		print(cam + " " + cam.transform.parent);

	}
	// Use this for initialization
	void Start () {
		previousCamPos = cam.position;
		backgrounds = GameObject.Find("Level").GetComponent<LevelCreator>().backgrounds;

		
	}
	
	// Update is called once per frame
	void Update () {
		print(previousCamPos.x + " " + cam.position.x + " " + parallaxScales);
		Vector3 parallax = (previousCamPos - cam.position) * parallaxScales;
		//float backgroundTargetPosX = backgrounds.transform.position.x + parallax;
		//Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds.transform.position.y, backgrounds.transform.position.z);
		//backgrounds.transform.position = backgroundTargetPos;// Vector3.Lerp(backgrounds.position, backgroundTargetPos, smoothing * Time.deltaTime);
		backgrounds.transform.Translate(parallax);
		print(parallax);
		previousCamPos = cam.position;
	}
}
