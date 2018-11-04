using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

	public string name;

	public AudioClip clip;

	public const float MaxPitch = 24f;
	public const float MinPitch = 0f;

	[Range(0f, 2f)]
	public float volume;
	[Range(MinPitch, MaxPitch)]
	public float pitch;
	[HideInInspector]
	public AudioSource source;

}
