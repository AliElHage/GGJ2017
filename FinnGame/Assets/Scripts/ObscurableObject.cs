using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObscurableObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Renderer renders = gameObject.GetComponent<Renderer>();

		renders.material.renderQueue = 4002;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
