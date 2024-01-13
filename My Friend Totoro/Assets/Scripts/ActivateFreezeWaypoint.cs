using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFreezeWaypoint : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);

        ChatTotoro.FlowerDance += ActivateTriggerPoint;
        FreezePlayer.TouchedCheckpoint += DeactivatetriggerPoint;
        
    }

    private void ActivateTriggerPoint()
    {
        gameObject.SetActive(true);
    }

    private void DeactivatetriggerPoint() { 
        gameObject.SetActive(false);
        ChatTotoro.FlowerDance -= ActivateTriggerPoint;
        FreezePlayer.TouchedCheckpoint -= DeactivatetriggerPoint;
    }
}
