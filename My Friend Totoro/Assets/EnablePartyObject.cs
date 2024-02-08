using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePartyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EndFirstDay.EndDaySecret += ActivateObject;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void ActivateObject()
    {
        gameObject.SetActive(true);
        EndFirstDay.EndDaySecret -= ActivateObject;
    }
}
