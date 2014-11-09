using UnityEngine;
using System.Collections;

public class portalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D e)
	{
		if (e.gameObject.tag == "Player") 
		{
			Application.LoadLevel(Application.loadedLevel + 1);
			PlayerPrefs.SetInt("PlayerValue", PlayerControl.value);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
