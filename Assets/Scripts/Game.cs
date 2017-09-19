using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game { 

	//public static Game current;
	private string winner;
	private long time;


	public Game (string winner, long time) {
		this.winner = winner;
		this.time = time;
	}

	public string getWinner() {
		return this.winner;
	}

	/*public string getTime() {
		//return (string) this.time;
	}*/

}