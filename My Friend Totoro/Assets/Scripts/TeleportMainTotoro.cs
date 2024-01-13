using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMainTotoro : MonoBehaviour
{
    public GameObject teleportPoint;

    public delegate void Transition();
    public static event Transition EnterDream;

    void Start()
    {
        if (teleportPoint == null) {
            Debug.LogError("Main Totoro Teleport Point for End of Day is not set");
            return;
        }

        EndFirstDay.EndDay += TeleportTotoro;
    }


    void TeleportTotoro() {
        Vector3 currentRotation = transform.rotation.eulerAngles;

        currentRotation.y = -209;

        transform.rotation = Quaternion.Euler(currentRotation);

        transform.position = teleportPoint.transform.position;

        EndFirstDay.EndDay -= TeleportTotoro;

        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(1f);
        if (EnterDream != null)
        {
            EnterDream();
        }
    }
}
