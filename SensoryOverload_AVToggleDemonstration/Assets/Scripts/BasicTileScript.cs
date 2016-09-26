using UnityEngine;
using System.Collections;

public class BasicTileScript : MonoBehaviour
{
    public enum TrapType { Normal, Death, Timed, Audio, Visual };
    public TrapType tileType;
    public float AVtimer = 3.0f;
    private bool onTile, AVtrap;
    private DeathTrap deathTrap = new DeathTrap();
    private TimedTrap timedTrap = new TimedTrap();
    private VisualTrap visualTrap = new VisualTrap();
    private TrapScript trap;
    private DeathScript death;
    private float elapsedTime;

    // Use this for initialization
    void Start ()
    {
        AVtrap = false;

        switch(tileType)
        {
            case TrapType.Audio:
                AVtrap = true;
                break;
            case TrapType.Visual:
                AVtrap = true;
                trap = visualTrap;
                break;
            case TrapType.Timed:
                trap = timedTrap;
                break;
            case TrapType.Death:
                trap = deathTrap;
                break;
            default:
                trap = null;
                break;
        }

        death = GameObject.FindGameObjectWithTag("DeathScript").GetComponent<DeathScript>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= AVtimer)
        {
            ResetAVTimer();
            if (AVtrap && onTile)
            {
                trap.Trigger(death);
            }
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            onTile = true;
            ResetAVTimer();
            if (trap != null && !AVtrap)
            {
                trap.Trigger(death);
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player")
        {
            onTile = false;
            ResetAVTimer();
        }
    }

    private void ResetAVTimer()
    {
        elapsedTime = 0.0f;
    }
}
