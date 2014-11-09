using UnityEngine;
using System.Collections;

public class handleHorseScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActionFunction(int value)
	{
		GameObject.FindWithTag ("Player").SendMessage ("Functionaized", Mathf.Sqrt((float)value));
		GameObject.Find ("Functions").SendMessage ("destroyEnemy", this.gameObject);
	}
	
	public void ActionFunctionPassive(int value)
	{
		GameObject.FindWithTag ("Stones").SendMessage ("Functionaized", Mathf.Sqrt((float)value));
		GameObject.Find ("Functions").SendMessage ("destroyEnemy", this.gameObject);
	}

}
