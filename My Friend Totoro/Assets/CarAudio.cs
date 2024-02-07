using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{

    public AudioClip carSound;
    public float delay = 0.1f;
    void Start()
    {
        StartCoroutine(ExecuteAfterDelay(delay));

    }

    private IEnumerator ExecuteAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        if (carSound != null)
        {
            Sounds soundInstance = Sounds.Instance;
            soundInstance.PlaySound(carSound);
        }
    }
}
