using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnComenzarController : MonoBehaviour {

	public void onBtnComenzarClick() {
		SceneManager.LoadScene ("game");
	}
}
