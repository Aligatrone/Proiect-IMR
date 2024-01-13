using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInTheCheckpoint : LevelBaseState
{
    private LevelStateManager stateMachine;

    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "Move into the checkpoint";
        FreezePlayer.TouchedCheckpoint += TransitionState;
    }

    public override void TransitionState()
    {
        FreezePlayer.TouchedCheckpoint -= TransitionState;
        stateMachine.SwitchState(new MoveHands());
    }

    public override void UpdateState()
    {

    }
}
