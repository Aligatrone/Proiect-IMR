using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUpdater : MonoBehaviour
{
    TextMeshProUGUI quest;
    public ParticleSystem[] susuwatariParticles;
    bool[] isFound;

    private Renderer[] renderHands;

    public GameObject[] hands;

    public Texture2D dirtyHandTexture;
    public Texture2D normalHandTexture;

    int found = 0;

    private void Start()
    {
        quest = GetComponent<TextMeshProUGUI>();
        quest.text = "Find the Susuwatari (0/4)";

        renderHands = new Renderer[hands.Length];
        for (int i = 0; i < hands.Length; i++) { 
            renderHands[i] = hands[i].GetComponent<Renderer>();
        }

        isFound = new bool[susuwatariParticles.Length];
    }

    void Update()
    {

        for (int i = 0; i < susuwatariParticles.Length; i++) {
            if (susuwatariParticles[i].isPlaying && !isFound[i]) {
                isFound[i] = true;
                found++;
                quest.text = $"Find the Susuwatari ({found}/4)";
            }
        }

        if (found == 4) {

            for (int i = 0; i < renderHands.Length; i++)
            {
                renderHands[i].material.SetTexture("_MainTex", dirtyHandTexture);
            }

            Invoke("SetQuestComplete", 1);
            found++;
        }

    }

    private void SetQuestComplete()
    {
            quest.text = "Quest Completed";
    }
}
