using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GardenGrowing : MonoBehaviour
{
    [SerializeField] private GameObject waterCan;
    public static event Action GardenWateredEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        WaterCanIsFilled.WateringEvent += WaterGarden;
    }

    // Update is called once per frame
    private void WaterGarden()
    {
        float distanceFromCan = Vector3.Distance(transform.position, waterCan.transform.position);
        
        if(distanceFromCan <= 2.0f)
            GardenWateredEvent?.Invoke();
    }
}
