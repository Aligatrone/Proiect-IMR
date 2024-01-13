using UnityEngine;

public abstract class LevelBaseState
{
    public abstract void EnterState(LevelStateManager levelSystem);

    public abstract void UpdateState();

    public abstract void TransitionState();
}
