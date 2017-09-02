using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	public Text player1Result;
	public Text player2Result;
	public GameObject btn;

	public GameObject coche1;
	public GameObject coche2;

	public GameObject audioCTRL;

	private AudioSource audioSource;
	private Coche1Controller coche1Controller;
	private Coche2Controller coche2Controller;
	private float startTime;
	public bool isFinished;

	// Use this for initialization
	void Start () {
		player1Result.text="";
		player2Result.text="";

		coche1Controller = coche1.GetComponent<Coche1Controller>();
		coche2Controller = coche2.GetComponent<Coche2Controller>();

		audioSource = audioCTRL.GetComponent<AudioSource> ();
	}

	void Update () {
		

		if (coche1Controller.barreraCount == 7) {
			isFinished = true;
			player1Result.text = "YOU WON!";
			player2Result.text = "YOU LOOSE!";
			btn.SetActive (true);
			audioSource.Stop();
		}
		if (coche2Controller.barreraCount > 7) {
			isFinished = true;
			player2Result.text = "YOU WON!";
			player1Result.text = "YOU LOOSE!";
			btn.SetActive (true);
			audioSource.Stop();
		}

	}
}
