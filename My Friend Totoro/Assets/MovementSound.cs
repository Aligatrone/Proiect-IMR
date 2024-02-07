using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip grass;
    public AudioClip wood;

    void Start()
    {
        DetectHouse.EnteredHouse += SwapToWoodSounds;
        DetectHouse.ExitedHouse += SwapToGrassSounds;
        CarCutscene.OnArrival += RemoveCarListener;
        audioSource.clip = wood;
    }

    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    private void RemoveCarListener()
    {
        CarCutscene.OnArrival -= RemoveCarListener;
        SwapToGrassSounds();
    }

    private void SwapToGrassSounds()
    {
        audioSource.clip = grass;
    }

    private void SwapToWoodSounds()
    {
        audioSource.clip = wood;
    }
}
