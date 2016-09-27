using System;
using UnityEngine;

[Serializable]
public class TimedTrap : TrapScript
{
    public override float GetTrapTimer()
    {
        return 0.0f;
    }
    public override void Trigger(DeathScript death)
    {
        if (GameObject.FindWithTag("GameController").GetComponent<GlobalTimer>().danger)
        {
            death.KillPlayer();
        }
    }
}
