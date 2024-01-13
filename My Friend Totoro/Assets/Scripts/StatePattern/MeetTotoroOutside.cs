using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetTotoroOutside : LevelBaseState
{
    private LevelStateManager stateMachine;

    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "Meet Totoro in the garden";
        ChatTotoro.FlowerDance += TransitionState;
    }

    public override void TransitionState()
    {
        ChatTotoro.FlowerDance -= TransitionState;
        stateMachine.SwitchState(new MoveInTheCheckpoint());
    }

    public override void UpdateState()
    {
        
    }
}
