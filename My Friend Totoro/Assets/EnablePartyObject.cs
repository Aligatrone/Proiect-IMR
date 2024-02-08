using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePartyObject : MonoBehaviour
{


    void Start()
    {
        EndFirstDay.EndDaySecret += ActivateObject;

        gameObject.SetActive(false);
    }

    void ActivateObject()
    {
        gameObject.SetActive(true);
        EndFirstDay.EndDaySecret -= ActivateObject;
    }
}
