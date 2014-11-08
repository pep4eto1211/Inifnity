using UnityEngine;
using System.Collections;

public class destroyFunctionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void destroyEnemy(GameObject objectToDestroy)
	{
		GameObject.Find ("Explosion").transform.position = objectToDestroy.transform.position;
		GameObject.Find ("Explosion").particleEmitter.emit = true;
		Destroy (objectToDestroy);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
