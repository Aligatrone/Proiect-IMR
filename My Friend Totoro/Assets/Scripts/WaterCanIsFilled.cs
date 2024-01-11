using UnityEngine;
using System;

public class WaterCanIsFilled : MonoBehaviour
{
    private bool isFilled;
    [SerializeField] private GameObject pumpLeaver;
    private Quaternion previousPumpRotation;
    [SerializeField] private ParticleSystem waterEffect;
    public static event Action WateringEvent;

    private void Start()
    {
        transform.Find("water").gameObject.SetActive(false);

        previousPumpRotation = pumpLeaver.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        TryToFill();

        IsWatering();
        
        transform.Find("water").gameObject.SetActive(isFilled);

        previousPumpRotation = pumpLeaver.transform.rotation;
    }

    void TryToFill()
    {
        float distanceFromPump = Vector3.Distance(transform.position, pumpLeaver.transform.position);
        
        if (pumpLeaver.transform.rotation != previousPumpRotation && distanceFromPump <= 1.5f)
            isFilled = true;
    }

    void IsWatering()
    {
        if (!isFilled)
            return;

        float angleZ = transform.rotation.eulerAngles.z;

        if (angleZ < 330 && angleZ > 300)
        {
            waterEffect.Play();
            isFilled = false;
            WateringEvent?.Invoke();
        }
    }
}
