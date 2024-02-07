using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds Instance { get; private set; }

    public AudioSource src;
    public AudioClip background;
    private List<AudioSource> soundSources = new List<AudioSource>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        PlayBackground();
    }

    private void PlayBackground()
    {
        if (src != null && background != null)
        {
            src.clip = background;
            src.Play();
            src.loop = true;
        }
        else
        {
            Debug.LogError("Background audio source or clip is not set.");
        }
    }

    public void PlaySound(AudioClip sound)
    {
        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        if (newSource != null && sound != null)
        {
            newSource.clip = sound;
            newSource.Play();
        }
        else
        {
            Debug.LogError("Audio source or sound clip is not set.");
        }
    }

    public void StopSound()
    {
        if (src != null)
        {
            src.Stop();
        }
        else
        {
            Debug.LogError("Audio source is not set.");
        }
    }


}
