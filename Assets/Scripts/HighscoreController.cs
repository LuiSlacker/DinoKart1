using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour {

	public Text scores;

	void Start () {
		loadHighscore ();
	}

	public void onBtnHighscoreClick() {
		SceneManager.LoadScene ("menu");
	}

	void loadHighscore() {
		string output = "";
		SaveLoad.load ();

		foreach(Game game in SaveLoad.savedGames) {
			output += game.getWinner () + "\n";
		}

		scores.text = output;
	}


}
