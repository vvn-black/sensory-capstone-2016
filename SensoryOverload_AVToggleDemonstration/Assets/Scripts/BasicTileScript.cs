using UnityEngine;
using System.Collections;

public class BasicTileScript : MonoBehaviour
{
    public enum TrapType { Normal, Death, Timed, Audio, Visual };
    public TrapType tileType;
    public VisualTrap visualTrap = new VisualTrap();
    public AudioTrap audioTrap = new AudioTrap();
    private bool onTile, active, AVtrap;
    private TrapScript trap;
    private DeathScript death;
    private float elapsedTime;
    private AudioSource buzzer;

    // Use this for initialization
    void Start ()
    {
        AVtrap = false;
        active = false;
        buzzer = GameObject.FindWithTag("Buzzer").GetComponent<AudioSource>();

        switch(tileType)
        {
            case TrapType.Audio:
                AVtrap = true;
                trap = audioTrap;
                break;
            case TrapType.Visual:
                AVtrap = true;
                trap = visualTrap;
                break;
            case TrapType.Timed:
                trap = new TimedTrap();
                break;
            case TrapType.Death:
                trap = new DeathTrap();
                break;
            default:
                trap = null;
                break;
        }

        death = GameObject.FindGameObjectWithTag("DeathScript").GetComponent<DeathScript>();
    }

    void Update()
    {
        if(active)
            elapsedTime += Time.deltaTime;

        if (AVtrap && elapsedTime >= trap.GetTrapTimer())
        {
            StopTimer();
            if (onTile)
            {
                trap.Trigger(death);
                // do explosion stuff here
                if (buzzer.isPlaying)
                {
                    buzzer.Stop();
                }
            }
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            onTile = true;
            if (AVtrap)
            {
                StartTimer();
                if (!buzzer.isPlaying)
                    buzzer.Play();
            }
            else if (trap != null)
                trap.Trigger(death);
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (buzzer.isPlaying)
            buzzer.Stop();
        if (c.tag == "Player")
            onTile = false;
    }

    private void ResetAVTimer()
    {
        elapsedTime = 0.0f;
    }

    public void StartTimer()
    {
        active = true;
    }

    public void StopTimer()
    {
        ResetAVTimer();
        active = false;
    }
}
