using UnityEngine;
using System.Collections;
using System;

public class DeathTrap : TrapScript
{
    public override void Trigger(DeathScript death)
    {
        death.KillPlayer();
    }
}
