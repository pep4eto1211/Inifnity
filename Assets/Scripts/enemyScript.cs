using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {

	public int value;
	public int demageResistance;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}

	public void receiveDemage(int receivedDemage)
	{
		demageResistance -= receivedDemage;
		if (demageResistance<0) 
		{
			GameObject.Find("Hero").SendMessage("receiveValue", Mathf.Abs(demageResistance));
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



















































