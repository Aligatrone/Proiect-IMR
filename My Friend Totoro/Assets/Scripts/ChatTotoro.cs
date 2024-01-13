using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChatTotoro : MonoBehaviour
{
    public GameObject[] bubbleText;

    private XRSimpleInteractable interactable;

    public delegate void Transition();
    public static event Transition ChatDone;

    public delegate void BeginDance();
    public static event BeginDance FlowerDance;

    private bool firstChat = true;

    private void Start()
    {
        gameObject.SetActive(false);

        WaterTheGarden.DoneWatering += SpawnMainTotoro;

        interactable = GetComponent<XRSimpleInteractable>();

        interactable.selectEntered.AddListener(OnGrabbed);

        SwapTime.TransitionDone += DespawnMainTotoro;

        TeleportMainTotoro.EnterDream += SpawnMainTotoro;
    }

    private void OnGrabbed(SelectEnterEventArgs arg0)
    {
        if (firstChat)
        {
            bubbleText[0].SetActive(true);
            StartCoroutine(TimerCoroutine());
        }
        else {
            bubbleText[1].SetActive(true);
            if (FlowerDance != null) {
                FlowerDance();
            }
        }
        
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
        firstChat = false;
    }

    private void SpawnMainTotoro() {
        gameObject.SetActive(true);
    }
}
