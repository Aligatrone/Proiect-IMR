using UnityEngine;

public class GetInsideTheHouse : LevelBaseState
{
    private LevelStateManager stateMachine;
    
    public override void EnterState(LevelStateManager levelSystem)
    {
        levelSystem.questTextBox.text = "Get inside the house.";
        stateMachine = levelSystem;
        
        CheckProximity.Entered += TransitionState;
    }

    public override void UpdateState()
    {
        
    }

    public override void TransitionState()
    {
        CheckProximity.Entered -= TransitionState;
        stateMachine.SwitchState(new CollectSusuwatari());
    }
}
