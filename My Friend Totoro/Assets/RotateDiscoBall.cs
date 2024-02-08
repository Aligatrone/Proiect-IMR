using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDiscoBall : MonoBehaviour
{
    private float rotationSpeed = 50f;

    private bool isActive = false;

    private void Start()
    {
        EndFirstDay.EndDaySecret += ActivateRotate;
    }

    void Update()
    {
        if (isActive)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    void ActivateRotate() {
        isActive = true;
    }
}
