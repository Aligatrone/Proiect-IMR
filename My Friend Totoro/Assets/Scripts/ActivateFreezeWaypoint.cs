using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFreezeWaypoint : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);

        ChatTotoro.FlowerDance += ActivateTriggerPoint;
    }

    private void ActivateTriggerPoint()
    {
        gameObject.SetActive(true);
    }
}
