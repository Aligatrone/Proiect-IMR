using UnityEngine;

public class LastMission : LevelBaseState
{
    private LevelStateManager stateMachine;
    
    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "Quest Complete";
    }

    public override void UpdateState()
    {

    }

    public override void TransitionState()
    {
        
    }
}