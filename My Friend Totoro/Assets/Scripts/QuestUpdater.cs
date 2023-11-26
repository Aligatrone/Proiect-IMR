using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUpdater : MonoBehaviour
{
    TextMeshProUGUI quest;
    public ParticleSystem susuwatari1;
    public ParticleSystem susuwatari2;
    public ParticleSystem susuwatari3;
    public ParticleSystem susuwatari4;
    bool isFound1 = false;
    bool isFound2 = false;
    bool isFound3 = false;
    bool isFound4 = false;

    int found = 0;

    private void Start()
    {
        quest = GetComponent<TextMeshProUGUI>();
        quest.text = "Find the Susuwatari (0/4)";
    }

    void Update()
    {
        if (susuwatari1.isPlaying && isFound1 == false)
        { 
                isFound1 = true;
                found++;
        }
        else if (susuwatari2.isPlaying && isFound2 == false)
        {
            isFound2 = true;
            found++;
        } else if (susuwatari3.isPlaying && isFound3 == false)
        {
            isFound3 = true;
            found++;
        } else if (susuwatari4.isPlaying && isFound4 == false)
        {
            isFound4 = true;
            found++;
        }
            
        quest.text = $"Find the Susuwatari ({found}/4)";
    }

    private void LateUpdate()
    {
        if (found == 4) {
            quest.text = "Quest Completed";
        }
    }
}
