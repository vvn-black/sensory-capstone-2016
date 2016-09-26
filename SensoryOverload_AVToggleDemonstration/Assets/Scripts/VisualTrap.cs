using UnityEngine;
using System.Collections;

public class VisualTrap : TrapScript
{
    public override void Trigger(DeathScript death)
    {
        death.KillPlayer(); 
    }
}
