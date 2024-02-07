using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHandGestures : MonoBehaviour
{

    public delegate void GestureDone();
    public static event GestureDone HandGestureDone;

    private bool shouldCheck;
    void Start()
    {
        shouldCheck = true;
    }

    void Update()
    {
        if (shouldCheck) {
            if (transform.childCount <= 0) {
                if (HandGestureDone != null) {
                    HandGestureDone();
                    shouldCheck = false;
                }
            }
        }
    }
}
