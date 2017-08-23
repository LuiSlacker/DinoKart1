using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundsound : MonoBehaviour {
	public AudioClip clip;
	public AudioSource music;
	// Use this for initialization
	void Start () {
		this.music.clip = clip;
		DontDestroyOnLoad (gameObject);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			music.Play();
		}
	}

}
