using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float movementThreshold = 0.01f;
    private Vector3 lastPosition;


    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        float distanceMoved = Vector3.Distance(currentPosition, lastPosition);

        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        if (distanceMoved > movementThreshold) {
            Debug.Log(distanceMoved);
            if (!audioSource.isPlaying) {
                audioSource.Play();    
                }
        }
        lastPosition = currentPosition;
    }
}
