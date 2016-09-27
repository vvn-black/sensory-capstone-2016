using System;

[Serializable]
public class AudioTrap : TrapScript
{
    public float trapTimer = 3.0f;
    public override float GetTrapTimer()
    {
        return trapTimer;
    }
    public override void Trigger(DeathScript death)
    {
        death.KillPlayer();
    }
}
