using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    private bool opening, opened;
    private float dist;
    public float speed, maxDist;
	// Use this for initialization
	void Start () {
        opening = false;
        opened = false;
        dist = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (opening && !opened)
        {
            dist += speed * Time.deltaTime;
            transform.GetChild(1).Translate(new Vector3(0, 0, speed * Time.deltaTime));
            if(dist >= maxDist)
            {
                opened = true;
            }
        }
	}

    public void openDoor()
    {
        opening = true;
    }
}
