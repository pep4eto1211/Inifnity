using UnityEngine;
using System.Collections;

public class destroyFunctionScript : MonoBehaviour {

	public GameObject projectile;

	// Use this for initialization
	void Start () {
	
	}

	public void destroyEnemy(GameObject objectToDestroy)
	{
		//GameObject.Find ("Explosion").transform.position = objectToDestroy.transform.position;
		//GameObject.Find ("Explosion").particleEmitter.emit = true;

		GameObject newGameObject = Instantiate (projectile, objectToDestroy.transform.position, Quaternion.identity) as GameObject;
		newGameObject.particleEmitter.emit = true;

		Destroy (objectToDestroy);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
