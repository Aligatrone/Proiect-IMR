using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutscene : MonoBehaviour
{
    private Collider carCollider;
    public GameObject boundary;

    public delegate void ArrivalCutsceneDone();
    public static event ArrivalCutsceneDone Arrived;
    void Start()
    {
        boundary.SetActive(false);
        carCollider = GetComponent<Collider>();
        carCollider.enabled = false;
        gameObject.SetActive(false);
        CarCutscene.OnArrival += HandleArrival;
    }

    void HandleArrival() { 
        gameObject.SetActive(true);
        carCollider.enabled = true;
        boundary.SetActive(true);
        if (Arrived != null) {
            Arrived();
        }
    }

    private void OnDestroy()
    {
        CarCutscene.OnArrival -= HandleArrival; 
    }
}
