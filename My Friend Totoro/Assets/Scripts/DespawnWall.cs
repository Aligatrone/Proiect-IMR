using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnWall : MonoBehaviour
{
    
    void Start()
    {
        QuestUpdater.DoneWatering += RemoveWall;
    }

    private void RemoveWall() { 
        gameObject.SetActive(false);
    }
}
