using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHandGestures : MonoBehaviour
{

    public delegate void GestureDone();
    public static event GestureDone HandGestureDone;

    private bool shouldCheck = false;
    void Start()
    {
        FreezePlayer.TouchedCheckpoint += ActivatePoints;
    }

    void Update()
    {
        if (shouldCheck) {
            if (transform.childCount <= 0) {
                if (HandGestureDone != null) {
                    HandGestureDone();
                }
            }
        }
    }

    private void ActivatePoints() {
        shouldCheck = true;
    }
}
