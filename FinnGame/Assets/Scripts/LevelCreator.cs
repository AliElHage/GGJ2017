	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

	public int levelLength;
	public GameObject floor, ceiling, background, backgrounds;
	public float levelHeight, floorOffset,
					backgroundXOffset, backgroundYOffset;
	private float segmentLength, backgroundWidth;

	// Use this for initialization
	void Start () {
		segmentLength = ceiling.GetComponent<MeshRenderer>().bounds.size.x;
		backgroundWidth = background.GetComponent<MeshRenderer>().bounds.size.x;
		GameObject level = GameObject.Find("Level");
		backgrounds = level.transform.GetChild(0).gameObject;
		print(segmentLength);
		Vector3 spawnPosition = transform.position, backgroundSpawn = transform.position + new Vector3(backgroundXOffset, backgroundYOffset, 14);

		for(int i = 0; i <= levelLength; i++)
		{
			var segmentDown = (GameObject)Instantiate(floor, spawnPosition - new Vector3(0, floorOffset, 0), Quaternion.Euler(90, 180, 0), level.transform);
			var segmentUp = (GameObject)Instantiate(ceiling, spawnPosition + new Vector3(0, levelHeight, 0), Quaternion.Euler(90, 180, 0), level.transform);
			var bgSegment = (GameObject)Instantiate(background, backgroundSpawn, Quaternion.Euler(90, 90, -90), backgrounds.transform);

			backgroundSpawn.x += backgroundWidth;
			spawnPosition.x += segmentLength;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
