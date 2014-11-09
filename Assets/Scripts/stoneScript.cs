using UnityEngine;
using System.Collections;

public class stoneScript : MonoBehaviour {

	public int value;

	// Use this for initialization
	void Start () {
	
	}

	public GameObject spawnObject;

	void OnTriggerEnter2D(Collider2D e)
	{
		if (e.gameObject.tag == "Player")
		{
			e.gameObject.SendMessage("StoneAvailable", this.gameObject);
		}
	}

	void OnTriggerLeave2D(Collider2D e)
	{
		if (e.gameObject.tag == "Player") 
		{
			e.gameObject.SendMessage("StoneUnavailable");
		}
	}

	void OnCollisionEnter2D(Collision2D e)
	{
		if(e.gameObject.tag == "Function")
		{
			e.gameObject.SendMessage("ActionFunction", value);
		}
		//Debug.Log ("Collision");
	}

	public void Functionaized(int newValue)
	{
		value = newValue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
