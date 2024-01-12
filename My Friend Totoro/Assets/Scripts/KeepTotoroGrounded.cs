using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepTotoroGrounded : MonoBehaviour
{
    private Rigidbody rb;
    public LayerMask groundLayer;
    private bool isRising = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TotoroGround1")) {
            StartRising();
        }

        if (other.CompareTag("TotoroGround2"))
        {
            StartLowering();
        }
    }

    private void StartRising()
    {
        if (!isRising)
        {
            StartCoroutine(RiseCoroutine());
        }
    }

    private void StartLowering()
    {
        if (!isRising)
        {
            StartCoroutine(LowerCoroutine());
        }
    }

    private IEnumerator RiseCoroutine()
    {
        isRising = true;
        float targetHeight = transform.position.y + 0.1f;

        while (transform.position.y < targetHeight)
        {
            float newY = Mathf.MoveTowards(transform.position.y, targetHeight, Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return null;
        }

        isRising = false;
    }

    private IEnumerator LowerCoroutine()
    {
        isRising = true;
        float targetHeight = transform.position.y - 0.1f;

        while (transform.position.y > targetHeight)
        {
            float newY = Mathf.MoveTowards(transform.position.y, targetHeight, Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return null;
        }

        isRising = false;
    }
}
