using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    TextMeshProUGUI questText;

    [SerializeField]
    private List<QuestState> questStates = new List<QuestState>();
    private QuestState currentState;
    private QuestData currentQuest;
    private int currentQuestIndex = 0; 

    void Start()
    {
        if (currentQuest != null && currentQuest.initialState != null)
        {
            questStates[0] = Instantiate(currentQuest.GetInitialState());
            currentState = questStates[0];
            questText = GetComponent<TextMeshProUGUI>();
            UpdateQuestText();
        }
    }

    
    void Update()
    {
        
    }

    void UpdateState() {
        if (currentState.nextState != null)
        {
            if (currentState.isComplete)
            {
                currentState = currentState.nextState;
                UpdateQuestText();
            }
        }
        else
        {
            print("Finished");
        }
    }

    void UpdateQuestText() {
        if (questStates[currentQuestIndex] != null) {
            questText.text = questStates[currentQuestIndex].task;
        }
    }
}
