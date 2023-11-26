using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WallDetection : MonoBehaviour
{
    public LayerMask boundaryLayer;

    private void OnTriggerEnter(Collider other)
    {
        if ((boundaryLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            transform.position = new Vector3(0f, 0f, 0f); 
        }
    }
}
