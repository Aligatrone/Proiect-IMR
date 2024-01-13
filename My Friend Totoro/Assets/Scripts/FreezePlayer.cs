using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{

    public delegate void TouchedCheckpointForDance();
    public static event TouchedCheckpointForDance TouchedCheckpoint;

    private bool firstEntry = true;

    private void Start()
    {
        gameObject.SetActive(false);

        ChatTotoro.FlowerDance += ActivateTriggerPoint;
    }

    private void ActivateTriggerPoint() { 
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (firstEntry && other.CompareTag("Player")) {
            firstEntry = false;
            if (TouchedCheckpoint != null) {
                TouchedCheckpoint();
            }
        }
    }
}
