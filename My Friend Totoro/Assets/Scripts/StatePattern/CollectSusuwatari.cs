using UnityEngine;
using System;

public class CollectSusuwatari : LevelBaseState
{
    private LevelStateManager stateMachine;
    private int numberOfSusuwatariFound;
    public static event Action AllSusuwatariFound;

    public override void EnterState(LevelStateManager levelSystem)
    {
        SusuwatariFinding.SusuwatariFind += SusuwatariWasFound;
        EndFirstDay.EndDaySecret += SecretEnding;
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = $"Find the Susuwatari ({numberOfSusuwatariFound}/4)";
    }

    public override void UpdateState()
    {
        
    }

    private void SusuwatariWasFound()
    {
        numberOfSusuwatariFound++;
        
        stateMachine.questTextBox.text = $"Find the Susuwatari ({numberOfSusuwatariFound}/4)";
        
        if (numberOfSusuwatariFound != 4) return;
        
        AllSusuwatariFound?.Invoke();
        TransitionState();
    }

    private void SecretEnding()
    {
        EndFirstDay.EndDaySecret -= SecretEnding;
        SusuwatariFinding.SusuwatariFind -= SusuwatariWasFound;
        stateMachine.SwitchState(new SecretEnding());
    }

    public override void TransitionState()
    {
        EndFirstDay.EndDaySecret -= SecretEnding;
        SusuwatariFinding.SusuwatariFind -= SusuwatariWasFound;
        stateMachine.SwitchState(new WashHands());
    }
}
