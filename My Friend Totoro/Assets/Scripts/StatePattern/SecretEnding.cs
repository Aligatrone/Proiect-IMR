using UnityEngine;
using System;

public class SecretEnding : LevelBaseState
{
    private LevelStateManager stateMachine;

    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "Talk with the big creature";
        EnableTotoro.Party += TransitionState;
    }

    public override void UpdateState()
    {
        
    }
    
    public override void TransitionState()
    {
        EnableTotoro.Party -= TransitionState;
        stateMachine.SwitchState(new EasterEgg());
    }
}