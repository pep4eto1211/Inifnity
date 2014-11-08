using UnityEngine;
using System.Collections;

public class destroyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void destroyEnemy(GameObject objectToDestroy)
	{
		GameObject.Find ("DemageZone").SendMessage ("removeFromList", objectToDestroy);
		Destroy (objectToDestroy);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
