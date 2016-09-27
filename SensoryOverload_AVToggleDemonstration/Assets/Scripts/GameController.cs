using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour 
{
	public AudioSource soundtrack;
	public AudioSource[] soundEffects;
    private RigidbodyFirstPersonController player;

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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<RigidbodyFirstPersonController>();
        //soundtrack.Play ();
        //player.transform.position = new Vector3(0, 0, 0);
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
