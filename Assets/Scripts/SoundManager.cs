using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager Instance = null;

	public AudioClip goalBloop;
	public AudioClip wallBloop;
	public AudioClip hitPaddleBloop;
	public AudioClip winSound;
	public AudioClip loseBuzz;

	private AudioSource soundEffectAudio;

	// Use this for initialization
	void Start () {
		//singleton
		if (Instance = null) {
			Instance = this;
		}
		else if (Instance != this) {
			Destroy (gameObject);
		}

		AudioSource[] sources = GetComponents<AudioSource> ();

		foreach (AudioSource source in sources) {
			if (source.clip == null) {
				soundEffectAudio = source;
			}
		}
	}
	
	public void playOneShot(AudioClip clip)
	{
		soundEffectAudio.PlayOneShot (clip);
	}
}
