using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour 
{
	public AudioSource soundtrack;
	public AudioSource[] soundEffects;

	// The game controller subscribes to these events from other classes
	void OnEnable()
	{	
		AVToggleHandler.goDeaf += Deaf;
		AVToggleHandler.goBlind += Blind;
	}

	void OnDisable()
	{
		AVToggleHandler.goDeaf -= Deaf;
		AVToggleHandler.goBlind -= Blind;
	}

	void Start () 
	{
		soundtrack.Play ();
	}

	void Deaf(float volume)
	{
		foreach (AudioSource audioSource in soundEffects) 
		{
			audioSource.volume = volume;
		}
	}

	void Blind(float volume)
	{
		foreach (AudioSource audioSource in soundEffects) 
		{
			audioSource.volume = volume;
		}
	}
}
