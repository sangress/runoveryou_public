using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour {
	public AudioSource audio;
	public AudioClip[] clips;
	public AudioClip[] endGameClips;
	public bool isLoop = false;

	void Start() {
		if (isLoop) {
			audio.clip = clips[0];
			audio.Play();
		}
	}

	void Update() {
		if (GameManager.instance != null) {
			audio.pitch = GameManager.instance.isSlowMoMode ? GameManager.instance.slowMoScale : 1f;
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player" || col.tag == "EndGame") {
			playSFX();
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.transform.tag == "Player") {
			playSFX();
		}
	}

	void playSFX() {
		AudioClip[] selectedClips = ((endGameClips.Length > 0) && GameManager.instance.isEnd()) ? endGameClips : clips;
		audio.clip = selectedClips[Random.Range(0, selectedClips.Length)];
		audio.Play();
	}
}
