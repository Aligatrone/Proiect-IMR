using UnityEngine;
using System;

public class UsingWaterPump : MonoBehaviour
{
    [SerializeField] private GameObject waterPumpParticles;
    [SerializeField] private GameObject waterPumpAnimator;
    public static event Action WaterPumpUsed;
    public AudioClip waterSound;
    
    public void WaterPumpIsUsed()
    {
        waterPumpParticles.GetComponent<ParticleSystem>().Play();
        waterPumpAnimator.GetComponent<Animator>().SetTrigger("isUsed");
        WaterPumpUsed?.Invoke();
        Sounds soundInstance = Sounds.Instance;
        soundInstance.PlaySound(waterSound);
    }
}
