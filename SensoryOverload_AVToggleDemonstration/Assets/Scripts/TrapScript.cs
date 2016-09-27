using UnityEngine;
using System.Collections;

public abstract class TrapScript
{
    public abstract float GetTrapTimer();
    public abstract void Trigger(DeathScript death);
}
