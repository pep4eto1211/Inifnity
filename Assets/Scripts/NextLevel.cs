using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void changeLevel()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
