using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundsound : MonoBehaviour {
	
	public AudioClip clip;
	public AudioSource music;

	void Start () {
		this.music.clip = clip;
		DontDestroyOnLoad (gameObject);
	}
		
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			music.Play();
		}
	}

}
