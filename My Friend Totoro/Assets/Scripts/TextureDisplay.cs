using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureDisplay : MonoBehaviour
{
    public Arm[] armTemplates;
    public GameObject hand;
    public GameObject sleeve;
    private Renderer[] renderHands;

    private void Start()
    {
        renderHands = new Renderer[2];
        renderHands[0] = hand.GetComponent<Renderer>();
        renderHands[1] = sleeve.GetComponent<Renderer>();

        CollectSusuwatari.AllSusuwatariFound += HandleNewTexture;

        WashHands.HandsWasWashed += RevertTexture;
    }

    private void UpdateTexture(Arm arm)
    {
        renderHands[0].material.SetTexture("_MainTex", arm.hand);
        renderHands[1].material = arm.sleeve;
        
    }

    private void HandleNewTexture() {
        UpdateTexture(armTemplates[1]);
    }

    private void RevertTexture() {
        UpdateTexture(armTemplates[0]);
    }
}
