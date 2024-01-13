using UnityEngine;

public class Cutscene : LevelBaseState
{
    private LevelStateManager stateMachine;
    
    public override void EnterState(LevelStateManager levelSystem)
    {
        levelSystem.questTextBox.text = "";
        stateMachine = levelSystem;
        
        EndCutscene.Arrived += TransitionState;
    }

    public override void UpdateState()
    {
        
    }

    public override void TransitionState()
    {
        EndCutscene.Arrived -= TransitionState;
        stateMachine.SwitchState(new GetInsideTheHouse());
    }
}
