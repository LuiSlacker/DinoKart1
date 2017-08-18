using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnController : MonoBehaviour {

	public void onBtnClick() {
		SceneManager.LoadScene ("menu");
	}
}
