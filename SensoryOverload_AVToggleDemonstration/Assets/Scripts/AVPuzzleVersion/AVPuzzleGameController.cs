using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AVPuzzleGameController : MonoBehaviour 
{
	//public AudioSource soundtrack;
	public AudioSource[] soundEffects;

	// The game controller subscribes to these events from other classes
	void OnEnable()
	{	
		AVPuzzleToggleHandler.goDeaf += Deaf;
		AVPuzzleToggleHandler.goBlind += Blind;
	}

	void OnDisable()
	{
		AVPuzzleToggleHandler.goDeaf -= Deaf;
		AVPuzzleToggleHandler.goBlind -= Blind;
	}

	void Start () 
	{
		//soundtrack.Play ();
	}

	void Deaf(float volume)
	{
		foreach (AudioSource audioSource in soundEffects) 
		{
            if (audioSource)
            {
                audioSource.volume = volume;
            }
		}
	}

	void Blind(float volume)
	{
		foreach (AudioSource audioSource in soundEffects) 
		{
            if (audioSource)
            {
                audioSource.volume = volume;
            }
		}
	}
}
