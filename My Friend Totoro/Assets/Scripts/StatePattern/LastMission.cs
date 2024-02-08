using System;
using UnityEngine;

public class LastMission : LevelBaseState
{
    private LevelStateManager stateMachine;
    public static event Action LastMissionCutscene;
    
    public override void EnterState(LevelStateManager levelSystem)
    {
        stateMachine = levelSystem;
        stateMachine.questTextBox.text = "The end!";
        LastMissionCutscene?.Invoke();
    }

    public override void UpdateState()
    {
        
    }

    public override void TransitionState()
    {
        
    }
}