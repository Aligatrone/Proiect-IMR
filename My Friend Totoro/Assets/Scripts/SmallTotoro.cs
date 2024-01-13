using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTotoro : MonoBehaviour
{
    private Animator animator;
    public GameObject checkpoint1;
    public GameObject checkpoint2;
    private bool firstCheckpoint;
    private bool reachedForest;

    public delegate void ForestEntered();
    public static event ForestEntered ArrivedAtForest;

    void Start()
    {
        gameObject.SetActive(false);

        firstCheckpoint = true;
        reachedForest = false;

        animator = GetComponent<Animator>();

        WaterTheGarden.DoneWatering += SpawnTotoro;

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
        
        if (other.CompareTag("TotoroCheckpoint"))
        {
            animator.SetBool("isPlayerNear", false);
            if (firstCheckpoint)
            {
                TurnTowardsCheckpoint(checkpoint1);
                firstCheckpoint = false;
            }
            else if(!firstCheckpoint)
            {
                TurnTowardsCheckpoint(checkpoint2);
                if (ArrivedAtForest != null) {
                    ArrivedAtForest();
                }
                reachedForest = true;
            }
        }

        if (other.CompareTag("FinalTotoroCheckpoint")) {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && reachedForest == false) {
            animator.SetBool("isPlayerNear", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !animator.GetBool("isPlayerNear")) {
            animator.SetBool("isPlayerNear", true);
        }
    }

    private void TurnTowardsCheckpoint(GameObject checkpoint) {
        Vector3 directionToCheckpoint = checkpoint.transform.position - transform.position;
        
        transform.forward = directionToCheckpoint;
    }

    private void SpawnTotoro() { 
        gameObject.SetActive(true);
    }
}
