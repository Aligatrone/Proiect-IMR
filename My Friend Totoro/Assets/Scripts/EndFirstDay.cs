using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EndFirstDay : MonoBehaviour
{

    public delegate void Transition();
    public static event Transition EndDay;

    private XRSimpleInteractable interactable;

    private void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        interactable.selectEntered.AddListener(OnGrabbed);

        interactable.enabled = false;

        ChatTotoro.ChatDone += ActivateInteractable;
    }

    private void OnGrabbed(SelectEnterEventArgs arg0)
    {
        if (EndDay != null) {
            EndDay();
        }
    }

    void ActivateInteractable() {
        interactable.enabled = true;
    }
}
