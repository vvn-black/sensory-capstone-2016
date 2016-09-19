using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;

public class AVToggleHandler : MonoBehaviour 
{
	public float darknessLevel, blurLevel, transitionSpeed, volume;
	public bool startBlind;
	private bool blind = false;
	private BlurOptimized blurryVision;
    private Grayscale grayscale;
	private Transform blindnessSprite;
	private float t = 0;
	private bool transition = false;

	// The GoDeaf event fires an alert to the GameController when the player turns on vision
	public delegate void GoDeaf(float volume);
	public static event GoDeaf goDeaf;

	// The GoBlind event fires an alert to the GameController when the player turns on hearing
	public delegate void GoBlind(float volume);
	public static event GoBlind goBlind;

	void Start () 
	{
		blurryVision = Camera.main.GetComponent<BlurOptimized> ();
        grayscale = Camera.main.GetComponent<Grayscale>();
		blindnessSprite = Camera.main.transform.FindChild ("BlindnessSprite");

		// If startBlind is checked, start blind with normal audio
		if (startBlind) 
		{
			StartBlind ();
			StartNormalAudio (volume);
			blind = true;
		}
		// Else if startBlind is not checked, start deaf with normal vision
		else
		{
			StartNormalVision ();
			StartDeaf (0);
			blind = false;
		}
	}
	
	void Update ()
	{
		// If input is AV toggle button ...
		if (Input.GetMouseButtonDown (0)) 
		{
			transition = true;
		}

		if (transition)
		{
			// If already blind, make deaf with normal vision
			if (blind) 
			{
				t += Time.deltaTime * transitionSpeed;
				blindnessSprite.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, Mathf.Lerp(blindnessSprite.GetComponent<SpriteRenderer> ().color.a, 0, t));
				blurryVision.downsample = (int)(Mathf.Lerp(blurryVision.downsample, 0, t));
				blurryVision.blurSize = Mathf.Lerp(blurryVision.blurSize, 0, t);
				blurryVision.blurIterations = (int)(Mathf.Lerp(blurryVision.blurIterations, 1, t));				
				StartDeaf (Mathf.Lerp(volume, 0, t));

				if (blindnessSprite.GetComponent<SpriteRenderer> ().color.a <= 0 && blurryVision.downsample <= 0 &&
				    blurryVision.blurSize <= 0 && blurryVision.blurIterations <= 1) 
				{
					blurryVision.enabled = false;
                    grayscale.enabled = false;
					blind = false;
					transition = false;
					StartDeaf (0);
					t = 0;
				}
			} 
			// Else make blind with normal audio
			else 
			{
				t += Time.deltaTime * transitionSpeed;
                grayscale.enabled = true;
                blindnessSprite.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, Mathf.Lerp(0, darknessLevel, t));
				blurryVision.enabled = true;
				blurryVision.downsample = (int)(Mathf.Lerp(0, (int)(blurLevel * 2), t));
				blurryVision.blurSize = Mathf.Lerp(0, blurLevel * 10, t);
				blurryVision.blurIterations = (int)(Mathf.Lerp(1, (int)(blurLevel * 4), t));
				StartNormalAudio (Mathf.Lerp(0, volume, t));

				if (blindnessSprite.GetComponent<SpriteRenderer> ().color.a >= darknessLevel && blurryVision.downsample >= (blurLevel*2) &&
					blurryVision.blurSize >= (blurLevel*10) && blurryVision.blurIterations >= (blurLevel*4)) 
				{
					blind = true;
					transition = false;
					StartNormalAudio (volume);
					t = 0;
				}
			}
		}
	}

	private void StartNormalVision()
	{
		blindnessSprite.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
		blurryVision.enabled = false;
	}

	public void StartBlind()
	{
		blindnessSprite.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, darknessLevel);
		blurryVision.enabled = true;
		blurryVision.downsample = (int)blurLevel * 2;
		blurryVision.blurSize = blurLevel * 10;
		blurryVision.blurIterations = (int)blurLevel * 4;
	}

	public void StartNormalAudio(float volume)
	{
		goBlind (volume);
	}

	public void StartDeaf(float volume)
	{
		goDeaf (volume);
	}
}