using UnityEngine;
using System.Collections;

public class EvilMinusScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float speed;

	public float direction = 1;
	
	public void FlipEnemy()
	{
		direction *= -1;
	}

	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2 (direction * speed, rigidbody2D.velocity.y);
	}

	public void ActionFunction(int value)
	{
		GameObject.FindWithTag ("Player").SendMessage ("Functionaized", value - 20);
		GameObject.Find ("Functions").SendMessage ("destroyEnemy", this.gameObject);
	}

	public void ActionFunctionPassive(int value)
	{
		GameObject.FindWithTag ("Stones").SendMessage ("Functionaized", value - 20);
		GameObject.Find ("Functions").SendMessage ("destroyEnemy", this.gameObject);
	}

}





















