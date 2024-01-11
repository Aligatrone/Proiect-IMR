using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTotoro : MonoBehaviour
{
    private Animator animator;
    public GameObject checkpoint1;
    public GameObject checkpoint2;
    private bool[] visitedCheckpoint;
    private bool canVerifyCheckpointCollisions = true;
    void Start()
    {
        gameObject.SetActive(false);
        visitedCheckpoint = new bool[3];
        animator = GetComponent<Animator>();
        QuestUpdater.DoneWatering += SpawnTotoro;
        if (checkpoint1 == null || checkpoint2 == null) {
            Debug.LogError("Checkpoints for small Totoro are not set!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isPlayerNear", true);
        }
        else if (other.CompareTag("TotoroCheckpoint") && canVerifyCheckpointCollisions)
        {
            animator.SetBool("isPlayerNear", false);
            if (visitedCheckpoint[0] == false)
            {
                TurnTowardsCheckpoint(checkpoint1);
                visitedCheckpoint[0] = true;
                StartCoroutine(DelayCheckTrigger());
            }
            else if (visitedCheckpoint[1] == false)
            {
                TurnTowardsCheckpoint(checkpoint2);
                visitedCheckpoint[1] = true;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        
    }

    IEnumerator DelayCheckTrigger() { 
        canVerifyCheckpointCollisions = false;
        yield return new WaitForSeconds(2.0f);
        canVerifyCheckpointCollisions = true;
    }

    private void TurnTowardsCheckpoint(GameObject checkpoint) {
        Vector3 directionToCheckpoint = checkpoint.transform.position - transform.position;
        transform.forward = directionToCheckpoint;
        checkpoint.SetActive(false);
    }

    private void SpawnTotoro() { 
        gameObject.SetActive(true);
    }
}
