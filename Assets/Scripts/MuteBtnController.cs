using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteBtnController : MonoBehaviour {

	public GameObject audioCTRL;

	private backgroundsound backgroundsound;

	public void onMuteBtnClick() {
		backgroundsound = audioCTRL.GetComponent<backgroundsound>();
		backgroundsound.music.mute = !backgroundsound.music.mute;
	}
}
