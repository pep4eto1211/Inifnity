using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class updatesScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();
	}

	Text text;

	public void showUpdate(string update)
	{
		if (update [0] == '-') 
		{
			text.color = new Color (1, 0.6f, 0.8f);
		}
		else 
		{
			text.color = new Color(0.6f, 1f, 0.6f);
		}
		text.text = update;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
