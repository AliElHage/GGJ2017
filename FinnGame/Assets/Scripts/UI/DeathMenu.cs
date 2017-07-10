using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = 0f;
        if(Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
        else if(Input.anyKeyDown && !Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("GameLevel");

    }
}
