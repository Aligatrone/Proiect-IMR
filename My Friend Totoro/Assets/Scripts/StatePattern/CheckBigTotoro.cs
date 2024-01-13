using UnityEngine;

public class CheckBigTotoro : LevelBaseState
{
    private LevelStateManager stateMachine;
    
    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "Check out the big creature";
        ChatTotoro.ChatDone += TransitionState;
    }

    public override void UpdateState()
    {

    }

    public override void TransitionState()
    {
        ChatTotoro.ChatDone -= TransitionState;
        stateMachine.SwitchState(new GoToBed());
    }
}