using System;
using UnityEngine;

public class SusuwatariFinding : MonoBehaviour
{
    [SerializeField] private GameObject susuwatariParticles;

    public static event Action SusuwatariFind;
    public AudioClip collectSound;

    public void SusuwatariTouch()
    {
        susuwatariParticles.GetComponent<ParticleSystem>().Play();
        this.gameObject.SetActive(false);
        Sounds soundInstance = Sounds.Instance;
        soundInstance.PlaySound(collectSound);
        
        SusuwatariFind?.Invoke();
    }
}
