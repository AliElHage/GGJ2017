using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public Canvas tutorial;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Input.anyKey)
        {
            tutorial.gameObject.SetActive(true);
            gameObject.SetActive(false);
            
        }
	}
}
