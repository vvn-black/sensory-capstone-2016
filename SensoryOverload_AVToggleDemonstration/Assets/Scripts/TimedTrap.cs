using UnityEngine;
using System.Collections;

public class TimedTrap : TrapScript
{
    public override void Trigger(DeathScript death)
    {
        if (GameObject.FindWithTag("GameController").GetComponent<GlobalTimer>().danger)
        {
            death.KillPlayer();
        }
    }
}
