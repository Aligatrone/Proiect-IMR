using UnityEngine;

public class GoToBed : LevelBaseState
{
    private LevelStateManager stateMachine;
    
    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "Go home and sleep";
        EndFirstDay.EndDay += TransitionState;
    }

    public override void UpdateState()
    {

    }

    public override void TransitionState()
    {
        EndFirstDay.EndDay -= TransitionState;
        stateMachine.SwitchState(new LastMission());
    }
}