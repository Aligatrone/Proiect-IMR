using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckProximity : MonoBehaviour
{
    public delegate void HouseAreaEntered();
    public static event HouseAreaEntered Entered;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            if (Entered != null) {
                Entered();
            }
        }
    }
}
