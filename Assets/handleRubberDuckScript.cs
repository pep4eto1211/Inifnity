using UnityEngine;
using System.Collections;

public class handleRubberDuckScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActionFunction(int value)
	{
		GameObject.FindWithTag ("Player").SendMessage ("Functionaized", value / 2);
		GameObject.Find ("Functions").SendMessage ("destroyEnemy", this.gameObject);
	}
	
	public void ActionFunctionPassive(int value)
	{
		GameObject.FindWithTag ("Stones").SendMessage ("Functionaized", value / 2);
		GameObject.Find ("Functions").SendMessage ("destroyEnemy", this.gameObject);
	}

}
