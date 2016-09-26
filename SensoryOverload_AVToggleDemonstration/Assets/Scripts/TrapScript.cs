using UnityEngine;
using System.Collections;

public abstract class TrapScript
{
    public BoxCollider col;
    public abstract void Trigger(DeathScript death);
}
