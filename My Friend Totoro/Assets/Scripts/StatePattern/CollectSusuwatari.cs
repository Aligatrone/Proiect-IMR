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

    public override void TransitionState()
    {
        SusuwatariFinding.SusuwatariFind -= SusuwatariWasFound;
        stateMachine.SwitchState(new WashHands());
    }
}
