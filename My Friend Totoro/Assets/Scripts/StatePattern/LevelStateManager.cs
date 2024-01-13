using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelStateManager : MonoBehaviour
{
    private LevelBaseState currentState;
    public TextMeshProUGUI questTextBox;
    // Start is called before the first frame update
    void Start()
    {
        currentState = new Cutscene();
        questTextBox = GetComponent<TextMeshProUGUI>();
        
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }

    public void SwitchState(LevelBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
