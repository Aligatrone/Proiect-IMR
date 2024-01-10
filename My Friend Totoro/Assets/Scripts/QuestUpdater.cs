using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestUpdater : MonoBehaviour
{
    TextMeshProUGUI quest;

    public ParticlesManager particlesManager;

    public static event Action allSusuwatariFound;
    public static event Action waterPumpUsed;

    int found = 0;

    private void Start()
    {
        quest = GetComponent<TextMeshProUGUI>();
        quest.text = "Find the Susuwatari (0/4)";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            found = 4;
        }
        if (found == 4) {

            allSusuwatariFound?.Invoke();

            // states = 2;
            Invoke("SetQuestComplete", 1);
        }
    }

    private void OnEnable()
    {
        if (particlesManager != null)
        {
            particlesManager.onParticleStart.AddListener(HandlerParticleStart);
            particlesManager.onWaterStart.AddListener(HandlerWaterStart);
        }
    }

    private void OnDisable()
    {
        if (particlesManager != null)
        {
            particlesManager.onParticleStart.RemoveListener(HandlerParticleStart);
            particlesManager.onWaterStart.RemoveListener(HandlerWaterStart);
        }
    }

    void HandlerParticleStart(ParticleSystem particleSystem)
    {
        found++;
        quest.text = $"Find the Susuwatari ({found}/4)";

    }

    void HandlerWaterStart(ParticleSystem waterSystem)
    {
        waterPumpUsed?.Invoke();

        if (found == 4)
        {
            found++;
            Invoke("SetQuestComplete", 1);
        }
    }

    private void SetQuestComplete()
    {
        switch (found) {
            case 4: quest.text = "Go to the water pump and wash your hands"; break;
            case 5: quest.text = "Quest Complete"; break;
            default: break;
        }
    }
}
