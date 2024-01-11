using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBubble : MonoBehaviour
{
    public GameObject mainCamera;
    void Update()
    {
        if (isActiveAndEnabled) {
            Debug.DrawRay(transform.position, transform.forward * 5f, Color.green);

            Vector3 directionToCamera = mainCamera.transform.position - transform.position;

            float step = 1f * Time.deltaTime;

            Vector3 newFacingDirection = Vector3.RotateTowards(transform.forward, directionToCamera, step, 0.0f);

            transform.rotation = Quaternion.LookRotation(newFacingDirection);
        }
    }
}