using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionUpdater : MonoBehaviour
{

    public GameObject vehicle;
    public GameObject player;
    public GameObject finalCheckpoint;
    bool debugCutsceneSkip = true;
    void Start()
    {
        if (vehicle == null || player == null || finalCheckpoint == null) {
            Debug.LogError("Vehicle/Player/FinalCheckpoint is not set!");
        }
        CarCutscene.OnArrival += HandleArrival;
        player.transform.parent = vehicle.transform;
    }

    void HandleArrival() {
        if (debugCutsceneSkip)
        {
            player.transform.parent = null;
            player.transform.position = finalCheckpoint.transform.position;
            debugCutsceneSkip = false;
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
            HandleArrival();
    }

    private void OnDestroy()
    {
        CarCutscene.OnArrival -= HandleArrival;
    }
}
