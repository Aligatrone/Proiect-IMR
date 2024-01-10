using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCutscene : MonoBehaviour
{
    public Transform firstCheckpoint;
    public Transform secondCheckpoint;
    public float speed = 0.03f;
    public float rotationSpeed = 1f;
    bool reachedCheckpointOne = false;
    bool reachedCheckpointTwo = false;
    float timeUntilDespawn = 2f;

    public delegate void ArrivalEventHandler();
    public static event ArrivalEventHandler OnArrival;

    private void Start()
    {
        if (firstCheckpoint == null || secondCheckpoint == null) {
            Debug.LogError("Checkpoints not placed");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!reachedCheckpointOne)
        {

            transform.position = Vector3.MoveTowards(transform.position, firstCheckpoint.transform.position, speed);

            if (Vector3.Distance(transform.position, firstCheckpoint.position) < 0.001f)
            {
                reachedCheckpointOne = true;

            }
        }
        else
        {
            MoveTowardsParking();
        }

    }

    void MoveTowardsParking()
    {

        if (!reachedCheckpointTwo)
        {
            Vector3 directionToSecondCheckpoint = secondCheckpoint.position - transform.position;

            float step = rotationSpeed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, directionToSecondCheckpoint, step, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDirection);

            speed = 0.7f;

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, secondCheckpoint.position) < 0.58f)
            {
                reachedCheckpointTwo = true;
            }
        }
        else
        {
           timeUntilDespawn -= Time.deltaTime;

            if (timeUntilDespawn <= 1f) {
                if (OnArrival != null)
                {
                    OnArrival();
                }
            }
            else if (timeUntilDespawn <= 0f)
            { 
                gameObject.SetActive(false);
            }
        }
    }
}