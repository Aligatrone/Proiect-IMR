using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutscene : MonoBehaviour
{
    private Collider collider;
    public GameObject boundary;

    public delegate void ArrivalCutsceneDone();
    public static event ArrivalCutsceneDone Arrived;
    void Start()
    {
        boundary.SetActive(false);
        collider = GetComponent<Collider>();
        collider.enabled = false;
        gameObject.SetActive(false);
        CarCutscene.OnArrival += HandleArrival;
    }

    void HandleArrival() { 
        gameObject.SetActive(true);
        collider.enabled = true;
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
