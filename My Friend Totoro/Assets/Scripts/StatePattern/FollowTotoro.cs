using UnityEngine;

public class FollowTotoro : LevelBaseState
{
    private LevelStateManager stateMachine;
    
    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "Follow the little creature";
        SmallTotoro.ArrivedAtForest += TransitionState;
    }

    public override void UpdateState()
    {

    }

    public override void TransitionState()
    {
        SmallTotoro.ArrivedAtForest -= TransitionState;
        stateMachine.SwitchState(new CheckBigTotoro());
    }
}
