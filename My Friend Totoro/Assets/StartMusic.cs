using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{

    private AudioSource src;

    void Start()
    {
        src = GetComponent<AudioSource>();

        EnableTotoro.Party += BeginMusic;
    }

    private void BeginMusic() {
        src.loop = true;
        src.Play();
    }
}
