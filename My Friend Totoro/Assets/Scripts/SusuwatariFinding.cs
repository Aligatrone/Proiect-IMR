using System;
using UnityEngine;

public class SusuwatariFinding : MonoBehaviour
{
    [SerializeField] private GameObject susuwatariParticles;

    public static event Action SusuwatariFind;

    public void SusuwatariTouch()
    {
        susuwatariParticles.GetComponent<ParticleSystem>().Play();
        this.gameObject.SetActive(false);
        
        SusuwatariFind?.Invoke();
    }
}
