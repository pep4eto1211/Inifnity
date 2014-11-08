using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {

	public int value;
	public int demageResistance;

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

	// Update is called once per frame
	void Update () {
	
	}
}
