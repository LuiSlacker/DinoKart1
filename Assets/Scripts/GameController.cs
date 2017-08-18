using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	public Text player1Result;
	public Text player2Result;

	private Coche1Controller coche1Controller;
	private Coche2Controller coche2Controller;

	// Use this for initialization
	void Start () {
		player1Result.text="";
		player2Result.text="";

		GameObject coche1 = GameObject.Find("Coche1");
		GameObject coche2 = GameObject.Find("Coche2");
		coche1Controller = coche1.GetComponent<Coche1Controller>();
		coche2Controller = coche2.GetComponent<Coche2Controller>();

		
	}
	
	// Update is called once per frame
	void Update () {
		if (coche1Controller.barreaCount > 3) {
			player1Result.text = "YOU WON!";
			player2Result.text = "YOU LOOSE!";
		}
		if (coche2Controller.barreaCount > 3) {
			player2Result.text = "YOU WON!";
			player1Result.text = "YOU LOOSE!";
		}

	}
}
