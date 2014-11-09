using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ValueScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();
		text.text = PlayerControl.value.ToString();
	}

	Text text;

	// Update is called once per frame
	void Update () {
		text.text = PlayerControl.value.ToString();
	}
}
