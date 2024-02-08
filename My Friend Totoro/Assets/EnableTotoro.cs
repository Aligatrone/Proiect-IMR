using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnableTotoro : MonoBehaviour
{

    private XRSimpleInteractable interactable;

    private bool hasBeenGrabbed = false;

    public GameObject bubbleText;
    public AudioClip totoroSounds;

    float volume = Mathf.Clamp01(1.0f);


    public delegate void BeginEasterEgg();
    public static event BeginEasterEgg Party;

    void Start()
    {
        EndFirstDay.EndDaySecret += ActivateTotoro;

        gameObject.SetActive(false);

        interactable = GetComponent<XRSimpleInteractable>();

        interactable.selectEntered.AddListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs arg0)
    {
        if (!hasBeenGrabbed) {
            hasBeenGrabbed = true;
            bubbleText.SetActive(true);
            Sounds soundInstance = Sounds.Instance;
            soundInstance.PlaySound(totoroSounds);
            if (Party != null) {
                Party();
            }

        }
    }

    private void ActivateTotoro()
    {
        gameObject.SetActive(true);
        EndFirstDay.EndDaySecret -= ActivateTotoro;
    }
}
