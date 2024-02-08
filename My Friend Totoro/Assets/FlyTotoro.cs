using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTotoro : MonoBehaviour
{
    private bool canMove;
    public Transform checkpointTransform;
    public float speed;
    
    void Start() {
        LastMission.LastMissionCutscene += MoveInvisibleBox;
    }
    
    private void Update() {
        if (!canMove) return;
        
        transform.position = Vector3.MoveTowards(transform.position, checkpointTransform.position, speed);
    }
    
    private void MoveInvisibleBox() {
        canMove = true;
    }
}
