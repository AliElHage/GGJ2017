using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {


    private bool pauseGame = false;
    private bool showGUI = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame = !pauseGame;
            if (pauseGame == true)
            {
                Time.timeScale = 0;
                pauseGame = true;
                GameObject.Find("PlayerSprite").GetComponent<DolphinController>().enabled = false;
                showGUI = true;

                Debug.Log("Escape key pressed");    

            }
        }
	 
        if(pauseGame == false)
        {
            Time.timeScale = 1;
            pauseGame = false;
            GameObject.Find("PlayerSprite").GetComponent<DolphinController>().enabled = true;
            showGUI = false;
        }
        if (showGUI == true)
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
        }
        else
        {
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        }


                
	}
}
