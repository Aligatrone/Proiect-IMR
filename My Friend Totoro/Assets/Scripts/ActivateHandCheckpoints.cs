using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHandCheckpoints : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        FreezePlayer.TouchedCheckpoint += ActivatePoints;
    }

    void ActivatePoints() { 
        gameObject.SetActive(true);
    }
}
