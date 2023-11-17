using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    static public Vector3 lastPosition;

    public void UpdatePosition()
    {
        lastPosition = camera.transform.position;
    }
}
