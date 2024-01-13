using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestUpdater : MonoBehaviour
{

    public delegate void FinishedWateringHandler();
    public static event FinishedWateringHandler DoneWatering;

    TextMeshProUGUI quest;

    public ParticlesManager particlesManager;
    
    public static event Action waterPumpUsed;

    int checkpointsReached = -1;

    private void Start()
    {
        quest = GetComponent<TextMeshProUGUI>();
        quest.text = "";
        EndCutscene.Arrived += NewQuest;
        CheckProximity.Entered += FirstCheckpoint;
        GardenGrowing.GardenWateredEvent += GardenWasWatered;
        SmallTotoro.ArrivedAtForest += ReachedForest;
        ChatTotoro.ChatDone += IsNight;
        EndFirstDay.EndDay += EndDay;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            checkpointsReached = 4;
        }
        if (checkpointsReached == 4) {

            Invoke("SetQuestComplete", 1);
        }
    }

    void NewQuest() {
        if (checkpointsReached == -1)
        {
            quest.text = "Go inside your new home";
            checkpointsReached++;
        }
    }

    void FirstCheckpoint() {
        quest.text = $"Find the Susuwatari ({checkpointsReached}/4)";
        CheckProximity.Entered -= FirstCheckpoint;
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
        if (checkpointsReached < 4)
        {
            checkpointsReached++;
            quest.text = $"Find the Susuwatari ({checkpointsReached}/4)";
        }
    }

    void HandlerWaterStart(ParticleSystem waterSystem)
    {
        waterPumpUsed?.Invoke();

        if (checkpointsReached == 4)
        {
            checkpointsReached++;
            Invoke("SetQuestComplete", 1);
        }
    }

    void GardenWasWatered()
    {
        if (checkpointsReached != 5)
            return;

        if (DoneWatering != null)
        {
            DoneWatering();
        }
        checkpointsReached++;
        SetQuestComplete();
    }

    void ReachedForest() {
        if (checkpointsReached != 6) {
            return;
        }

        checkpointsReached++;
        SetQuestComplete();
    }

    void IsNight() {
        if (checkpointsReached != 7) {
            return;
        }

        checkpointsReached++;
        SetQuestComplete();
    }

    void EndDay() {
        if (checkpointsReached != 8) {
            return;
        }

        checkpointsReached++;
        SetQuestComplete();
    }

    private void SetQuestComplete()
    {
        switch (checkpointsReached) {
            case 4: quest.text = "Go to the water pump and wash your hands"; break;
            case 5: quest.text = "Water the garden"; break;
            case 6: quest.text = "Follow the little creature"; break;
            case 7: quest.text = "Check out the big creature"; break;
            case 8: quest.text = "Go home and sleep"; break;
            case 9: quest.text = "Quest Complete"; checkpointsReached = 99; break;
            default: break;
        }
    }

    private void OnDestroy()
    {
        EndCutscene.Arrived -= NewQuest;
    }
}
