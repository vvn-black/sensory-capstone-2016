using System;

[Serializable]
public class DeathTrap : TrapScript
{
    public override float GetTrapTimer()
    {
        return 0.0f;
    }
    public override void Trigger(DeathScript death)
    {
        death.KillPlayer();
    }
}
