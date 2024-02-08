using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EndFirstDay : MonoBehaviour
{

    public delegate void Transition();
    public static event Transition EndDay;
    public static event Transition EndDaySecret;

    private XRSimpleInteractable interactable;
    private bool secretEnding = true;
    private bool shouldTransition = true;

    private void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        interactable.selectEntered.AddListener(OnGrabbed);
        
        ChatTotoro.ChatDone += NotSecretEnding;
    }

    private void OnGrabbed(SelectEnterEventArgs arg0)
    {
        if (secretEnding)
        {
            if (shouldTransition)
            {
                shouldTransition = false;
                EndDaySecret?.Invoke();
            }
        }
        else
        {
            EndDay?.Invoke();
        }
    }

    private void NotSecretEnding()
    {
        secretEnding = false;
    }
}
