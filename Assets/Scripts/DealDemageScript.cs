﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DealDemageScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	//List of all objects who will receive demage
	private List<GameObject> objectsInDangerZone = new List<GameObject>();
	public int demageDeal;

	void OnTriggerEnter2D(Collider2D e)
	{
		if (e.gameObject.tag == "Enemy") 
		{
			objectsInDangerZone.Add(e.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D e)
	{
		if (e.gameObject.tag == "Enemy") 
		{
			objectsInDangerZone.Remove(e.gameObject);
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			GameObject.Find ("Hero").GetComponent<Animator> ().SetBool ("isAttacking", true);
			Debug.Log("Bool sent");
			foreach (GameObject item in objectsInDangerZone) 
			{
				item.SendMessage ("receiveDemage", demageDeal);
			}
		} 
	}

	public void removeFromList(GameObject objectToRemove)
	{
		objectsInDangerZone.Remove (objectToRemove);
	}
}




































































