using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;
	private bool play;
	private bool stopLoop;
	private int shift;
	private float pitch;

	// Use this for initialization
	void Start () {
		foreach (Sound s in sounds) {
			// initialize start sound
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}

		play = false;
		stopLoop = false;
		shift = 0;
	}

	public void PlayLoop () {
		sounds[0].source.Play();
		stopLoop = false;
		/*if (!stopLoop) {
			sounds[1].source.Play();
			sounds[1].source.loop = true;
		}*/
		StartCoroutine("Loop");
	}

	public void ChangePitch (float slidePos) {
		float temp = slidePos;

		temp += 3.5f;
		temp *= 3.5f;

		if (temp > Sound.MaxPitch) {
			temp = Sound.MaxPitch;
		} else if (temp < Sound.MinPitch) {
			temp = Sound.MinPitch;
		}

		pitch = (float) Math.Pow(2, (double) ((-19 + Sound.MaxPitch - temp) / 12));

		sounds[0].source.pitch = pitch;
		sounds[1].source.pitch = pitch;
	}

	IEnumerator Loop () {
		yield return new WaitForSeconds(0.146f / pitch);

		if (!stopLoop) {
			sounds[1].source.Play();
			sounds[1].source.loop = true;
		}
	}

	public void EndLoop () {
		stopLoop = true;
		sounds[1].source.loop = false;
		sounds[0].source.Stop();
		sounds[1].source.Stop();
	}
}
