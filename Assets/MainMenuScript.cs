using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		if (!PlayerPrefs.HasKey ("PlayerValue")) 
		{
			PlayerPrefs.SetInt("PlayerValue", 0);
		}
	
	}

	public void quitGame()
	{
		Application.Quit ();
	}

	public void startGame ()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
