using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/State")]
public class QuestState : ScriptableObject
{
    public string task;
    public int requiredObjectives;
    public QuestEvent onStateEnter;
    public QuestState nextState;
    public bool isComplete;
}

[System.Serializable]
public class QuestEvent : UnityEngine.Events.UnityEvent<int> { }
