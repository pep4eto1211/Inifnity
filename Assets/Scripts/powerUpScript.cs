using UnityEngine;
using System.Collections;

public class powerUpScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public int value;

	public void SetValue(int newValue)
	{
		value = newValue;
	}

	void OnCollisionEnter2D(Collision2D e)
	{
		if (e.gameObject.tag == "Player") 
		{
			e.gameObject.SendMessage("receiveValue", value);
			Destroy(this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
