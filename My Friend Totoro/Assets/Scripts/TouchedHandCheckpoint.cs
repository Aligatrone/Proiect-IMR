using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchedHandCheckpoint : MonoBehaviour
{

    private XRSimpleInteractable interactable;

    private void OnEnable()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        interactable.hoverEntered.AddListener(OnHoverEntered);
    }

    private void OnDestroy()
    {
        interactable.hoverEntered.RemoveListener(OnHoverEntered);
    }

    private void OnHoverEntered(HoverEnterEventArgs arg0)
    {
        Destroy(gameObject);
    }
}
