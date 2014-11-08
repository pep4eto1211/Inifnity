using UnityEngine;
using System.Collections;

public class pigFlyingScript : MonoBehaviour {
	public float speed = 5f;
	public float range = 20f;
	private float startX;
	private float currentX;
	public float Health;
	// Use this for initialization
	void Start () {
		startX = this.transform.localPosition.x;
		Debug.Log ("position " + this.startX.ToString ());
	}

	public void receiveDamage(int receivedDamage)
	{
		Health -= receivedDamage;
		if (Health<0) 
		{
			GameObject.Find("TheGoodHero").SendMessage("receiveValue", Mathf.Abs(Health));
			GameObject.Find("Enemies").SendMessage("destroyEnemy", gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		//currentX = this.transform.localPosition.x;
		Vector3 oldPos = this.transform.localPosition;
		this.transform.position = new Vector3 (oldPos.x - (speed * Time.deltaTime), oldPos.y, oldPos.z);//moving left

		if (startX - oldPos.x > range) {
			this.transform.position = new Vector3 (startX, oldPos.y, oldPos.z);
		}
	}
}
