using UnityEngine;

public class WaterTheGarden : LevelBaseState
{
    private LevelStateManager stateMachine;
    public delegate void FinishedWateringHandler();
    public static event FinishedWateringHandler DoneWatering;
    
    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "Water the garden";
        GardenGrowing.GardenWateredEvent += TransitionState;
    }

    public override void UpdateState()
    {
        
    }
    
    public override void TransitionState()
    {
        GardenGrowing.GardenWateredEvent -= TransitionState;
        DoneWatering?.Invoke();
        stateMachine.SwitchState(new FollowTotoro());
    }
}
