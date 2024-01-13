using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHands : LevelBaseState
{
    private LevelStateManager stateMachine;

    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "Move your hands to match the pattern";
        CheckHandGestures.HandGestureDone += TransitionState;
    }

    public override void TransitionState()
    {
        CheckHandGestures.HandGestureDone -= TransitionState;
        stateMachine.SwitchState(new LastMission());
    }

    public override void UpdateState()
    {

    }
}
