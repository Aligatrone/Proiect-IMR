using UnityEngine;

public class PlantGrowing : MonoBehaviour
{
    private Animator plantAnimator;
    // Start is called before the first frame update
    void Start()
    {
        plantAnimator = this.GetComponent<Animator>();
        CheckHandGestures.HandGestureDone += GrowPlant;
    }
    
    void GrowPlant()
    {
        plantAnimator.SetTrigger("Growing");
    }
}
