using UnityEngine;
using System.Collections;

public class reverseEnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D e)
	{
		e.gameObject.SendMessage ("FlipEnemy");
	}
}
