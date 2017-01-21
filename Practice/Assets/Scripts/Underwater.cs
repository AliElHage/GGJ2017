using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour {

	private bool isUnderwater;
	private Color normalColor;
	private Color underwaterColor;

	// Use this for initialization
	void Start () {
		normalColor = new Color(.5F, .5F, .5F, .5F);
		underwaterColor = new Color(.22F, .65F, .77F, .5F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
