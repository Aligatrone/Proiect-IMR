using UnityEngine;

public class WaterCanIsFilled : MonoBehaviour
{
    private bool isFilled;
    private MeshRenderer waterRenderer;
    [SerializeField] private GameObject pumpLeaver;
    private Quaternion previousPumpRotation;

    private void Start()
    {
        waterRenderer = GetComponent<MeshRenderer>();

        previousPumpRotation = pumpLeaver.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        TryToFill();

        IsWatering();
        
        waterRenderer.enabled = isFilled;

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

        float angleZ = transform.rotation.z;
    }
}
