using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : LevelBaseState
{

    private LevelStateManager stateMachine;

    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "What?";
    }

    public override void TransitionState()
    {
        
    }

    public override void UpdateState()
    {
        
    }
}
