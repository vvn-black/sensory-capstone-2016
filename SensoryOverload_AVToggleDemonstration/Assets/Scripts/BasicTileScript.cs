﻿using UnityEngine;
using System.Collections;

public class BasicTileScript : MonoBehaviour
{
    public enum TrapType { Normal, Death, Timed, Audio, Visual };
    public TrapType tileType;
    private DeathTrap deathTrap = new DeathTrap();
    private TrapScript trap;
    //private AudioTrapScript audioTrap;
    //private VisualTrapScript visualTrap;
    //private TimedTrapScript timedTrap;
    private DeathScript death;

    // Use this for initialization
    void Start ()
    {
        // ... then enable only the one checked by the game designer
        switch(tileType)
        {
            case TrapType.Audio:
            case TrapType.Visual:
            case TrapType.Timed:
            case TrapType.Death:
                trap = deathTrap;
                break;
            default:
                trap = null;
                break;
        }
        death = GameObject.FindGameObjectWithTag("DeathScript").GetComponent<DeathScript>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            Debug.Log("Colliding with player!");
            trap.Trigger(death);
        }
    }
}
