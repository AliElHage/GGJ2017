using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedMenu : MonoBehaviour {

	private bool pausedGame = false;
	private bool showGUI = false;

	//Audio variables
	private AudioSource audioSource;
	public AudioClip pausedSound;
	private float volume;
	

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			pausedGame = !pausedGame;
			if(pausedGame == true)
			{
				Time.timeScale = 0f;
				pausedGame = true;
				GameObject.Find("PlayerSprite").GetComponent<DolphinController>().enabled = false;
				showGUI = true;

				//Audio : remember to add an audio sound.
				volume = Random.Range(.5f, 1f);
				audioSource.PlayOneShot(pausedSound, volume);
			}
		}	
		
		if(pausedGame==false)
		{
			Time.timeScale = 1f;
			pausedGame = false;
			GameObject.Find("PlayerSprite").GetComponent<DolphinController>().enabled = true;
			showGUI = false;
		}

		if (showGUI == true)
		{
			transform.GetChild(1).gameObject.SetActive(true);
		//	GameObject.Find("PauseScreen").SetActive(true);
		}
		else
		{
			transform.GetChild(1).gameObject.SetActive(false);

	//		GameObject.Find("PauseScreen").SetActive(false);
		}
	}
}
