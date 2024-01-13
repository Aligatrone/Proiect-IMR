using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFreezeColliders : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        FreezePlayer.TouchedCheckpoint += Activate;
    }

    private void Activate() { 
        gameObject.SetActive(true);
    }
}
