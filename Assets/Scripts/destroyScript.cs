using UnityEngine;
using System.Collections;

public class destroyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public GameObject projectile;

	public void destroyEnemy(GameObject objectToDestroy)
	{
		GameObject.Find ("DamageZone").SendMessage ("removeFromList", objectToDestroy);
		/*
		GameObject.Find ("Explosion").transform.position = objectToDestroy.transform.position;
		GameObject.Find ("Explosion").particleEmitter.emit = true;
		*/
		GameObject newGameObject = Instantiate (projectile, objectToDestroy.transform.position, Quaternion.identity) as GameObject;
		newGameObject.particleEmitter.emit = true;
		Destroy (objectToDestroy);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
