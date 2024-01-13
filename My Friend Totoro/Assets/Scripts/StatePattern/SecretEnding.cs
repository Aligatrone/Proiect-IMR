using UnityEngine;
using System;

public class SecretEnding : LevelBaseState
{
    private LevelStateManager stateMachine;

    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "You never found Totoro :(";
    }

    public override void UpdateState()
    {
        
    }
    
    public override void TransitionState()
    {

    }
}