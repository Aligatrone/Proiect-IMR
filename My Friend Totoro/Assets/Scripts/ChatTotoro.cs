using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChatTotoro : MonoBehaviour
{
    public GameObject[] bubbleText;
    public AudioClip[] totoroSounds;

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
        
        LastMission.LastMissionCutscene += TalkFlying;
    }

    private void OnGrabbed(SelectEnterEventArgs arg0)
    {
        if (firstChat)
        {
            bubbleText[0].SetActive(true);
            Sounds soundInstance = Sounds.Instance;
            soundInstance.PlaySound(totoroSounds[0]);
            
            StartCoroutine(TimerCoroutine());
        }
        else {
            bubbleText[1].SetActive(true);
            Sounds soundInstance = Sounds.Instance;
            soundInstance.PlaySound(totoroSounds[1]);
            
            if (FlowerDance != null) {
                FlowerDance();
            }
        }
        
    }

    private void TalkFlying() {
        Sounds soundInstance = Sounds.Instance;
        soundInstance.PlaySound(totoroSounds[2]);
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
