using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ParticleEvent : UnityEvent<ParticleSystem> { }

public class ParticlesManager : MonoBehaviour
{
    public ParticleSystem[] particlesToWatch;
    public ParticleEvent onParticleStart;
    public ParticleEvent onWaterStart;


    private bool[] hasStarted;

    private void Start()
    {
        hasStarted = new bool[particlesToWatch.Length];
    }

    private void Update()
    {
        for (int i = 0; i < particlesToWatch.Length; i++) {

            if (particlesToWatch[i].isPlaying && !hasStarted[i]) {

                if (particlesToWatch[i].name == "Water")
                {
                    onWaterStart.Invoke(particlesToWatch[i]);
                    hasStarted[i] = true;
                }
                else
                {
                    onParticleStart.Invoke(particlesToWatch[i]);
                    hasStarted[i] = true;
                }

            }

            if (!particlesToWatch[i].isPlaying && particlesToWatch[i].name == "Water" && hasStarted[i] == true) {
                hasStarted[i] = false;
            }

        }

    }
}
