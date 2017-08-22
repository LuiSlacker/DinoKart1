﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	public Text player1Result;
	public Text player2Result;
	public Text time;
	public GameObject btn;

	public GameObject coche1;
	public GameObject coche2;

	private Coche1Controller coche1Controller;
	private Coche2Controller coche2Controller;

	// Use this for initialization
	void Start () {
		player1Result.text="";
		player2Result.text="";

		coche1Controller = coche1.GetComponent<Coche1Controller>();
		coche2Controller = coche2.GetComponent<Coche2Controller>();

		
	}

	// Update is called once per frame
	void Update () {
		float t = Time.time;
		time.text = "Time: " + Mathf.Round(t * 1000.0f) / 1000.0f;;

		if (coche1Controller.barreaCount > 3) {
			player1Result.text = "YOU WON!";
			player2Result.text = "YOU LOOSE!";
			btn.SetActive (true);
		}
		if (coche2Controller.barreaCount > 3) {
			player2Result.text = "YOU WON!";
			player1Result.text = "YOU LOOSE!";
			btn.SetActive (true);
		}

	}
}
