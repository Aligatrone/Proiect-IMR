using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCutscene : MonoBehaviour
{
    public Transform firstCheckpoint;
    public Transform secondCheckpoint;
    public float speed = 0.05f;
    public float rotationSpeed = 1.2f;
    bool reachedCheckpointOne = false;
    bool reachedCheckpointTwo = false;

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
        } else {
            MoveTowardsParking();
        }

    }

    void MoveTowardsParking() {

        if (!reachedCheckpointTwo)
        {
            Vector3 directionToSecondCheckpoint = secondCheckpoint.position - transform.position;

            float step = rotationSpeed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, directionToSecondCheckpoint, step, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDirection);

            speed = 0.7f;

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            Debug.Log(Vector3.Distance(transform.position, secondCheckpoint.position));

            if (Vector3.Distance(transform.position, secondCheckpoint.position) < 0.58f)
            {
                reachedCheckpointTwo = true;
            }
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
