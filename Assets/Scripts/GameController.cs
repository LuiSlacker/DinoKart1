using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	Coche1Controller coche1Controller;

	// Use this for initialization
	void Start () {
		GameObject coche1 = GameObject.Find("Coche1");
		coche1Controller = coche1.GetComponent<Coche1Controller>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (coche1Controller.barreaCount > 3) {
			Debug.Log ("Player1 wins");
		}

	}
}
