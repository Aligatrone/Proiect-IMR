using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Data")]
public class QuestData : ScriptableObject
{
    public QuestState initialState;

    public List<QuestState> states;
    
    public QuestState GetInitialState() {
        return initialState;
    }

    public List<QuestState> GetAllStates() {
        return states;
    }
}
