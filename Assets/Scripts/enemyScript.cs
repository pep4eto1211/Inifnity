using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {

	public int value;
	public int Health;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}

	public void receiveDamage(int receivedDamage)
	{
		Health -= receivedDamage;
		if (Health<0) 
		{
			GameObject.Find("TheGoodHero").SendMessage("receiveValue", Mathf.Abs(Health));
			GameObject.Find("Enemies").SendMessage("destroyEnemy", this.gameObject);
		}
	}

	public float direction = 1;

	public void FlipEnemy()
	{
		direction *= -1;
	}

	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2 (direction * speed, rigidbody2D.velocity.y);
	}
}



















































