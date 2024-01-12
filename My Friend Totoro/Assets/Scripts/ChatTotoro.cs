using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChatTotoro : MonoBehaviour
{
    private XRSimpleInteractable interactable;

    public delegate void Transition();
    public static event Transition ChatDone;

    private void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();

        interactable.selectEntered.AddListener(OnGrabbed);

        SwapTime.TransitionDone += DespawnMainTotoro;
    }

    private void OnGrabbed(SelectEnterEventArgs arg0)
    {
        StartCoroutine(TimerCoroutine());
        
    }

    private IEnumerator TimerCoroutine() {
        yield return new WaitForSeconds(2f);
        if (ChatDone != null)
        {
            ChatDone();
        }
    }

    private void DespawnMainTotoro() { 
        gameObject.SetActive(false);
    }
}
