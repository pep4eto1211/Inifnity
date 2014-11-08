using UnityEngine;
using System.Collections;

public class killable : MonoBehaviour {

	public float Health;
	// Use this for initialization
	void Start () {

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

	}
}
