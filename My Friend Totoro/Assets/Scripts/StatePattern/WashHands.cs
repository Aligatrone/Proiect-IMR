using UnityEngine;
using System;

public class WashHands : LevelBaseState
{
    private LevelStateManager stateMachine;
    public static event Action HandsWasWashed;
    
    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "Go to the water pump and wash your hands";
        UsingWaterPump.WaterPumpUsed += TransitionState;
    }

    public override void UpdateState()
    {
        
    }

    public override void TransitionState()
    {
        HandsWasWashed?.Invoke();
        UsingWaterPump.WaterPumpUsed -= TransitionState;
        stateMachine.SwitchState(new WaterTheGarden());
    }
}
